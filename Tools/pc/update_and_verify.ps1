# Brings this PC's copy of Project Ascend up to date with GitHub and checks it end to end:
#   1. pulls the latest main from GitHub (fast-forward only; stops if you have uncommitted changes)
#   2. npm run build (data + C# rules tests, the same as CI)
#   3. rebuilds the Ring 0 scene (Ring0SceneBuilder.BuildBatch)
#   4. runs the Unity PlayMode tests
#   5. builds the Ring 0 player and takes review screenshots
# Everything is logged under Game/Logs/verify_<time>/ (gitignored); a summary prints at the end.
# The player's save in AppData/LocalLow is never touched: tests and screenshots use temporary save folders.
#
# Double-click Tools/pc/update_and_verify.cmd, or run:
#   powershell -ExecutionPolicy Bypass -File Tools/pc/update_and_verify.ps1 [-SkipPull] [-SkipPlayer]
param(
    [string]$Unity = "E:/Unity/Editors/6000.6.7f1/Editor/Unity.exe",
    [string]$Remote = "aetheria",
    [string]$Branch = "main",
    [switch]$SkipPull,
    [switch]$SkipPlayer
)

$ErrorActionPreference = "Stop"
$Repo = (Resolve-Path (Join-Path $PSScriptRoot "../..")).Path
$Safe = $Repo -replace '\\', '/'
$Stamp = Get-Date -Format "yyyy-MM-dd_HHmm"
$Out = Join-Path $Repo "Game/Logs/verify_$Stamp"
New-Item -ItemType Directory -Force -Path $Out | Out-Null
$Results = [System.Collections.Generic.List[object]]::new()

function RepoGit { & git -c "safe.directory=$Safe" -C $Repo @args }
function Step([string]$Name, [string]$Status, [string]$Detail) {
    $Results.Add([pscustomobject]@{ Step = $Name; Status = $Status; Detail = $Detail })
    $color = switch ($Status) { "OK" { "Green" } "FAILED" { "Red" } default { "Yellow" } }
    Write-Host ("[{0}] {1}  {2}" -f $Status, $Name, $Detail) -ForegroundColor $color
}
function RunUnity([string]$Log, [string[]]$UnityArgs) {
    $all = @("-batchmode", "-projectPath", (Join-Path $Repo "Game"), "-logFile", $Log) + $UnityArgs
    $quoted = $all | ForEach-Object { if ($_ -match '\s') { '"' + $_ + '"' } else { $_ } }
    $p = Start-Process -FilePath $Unity -ArgumentList $quoted -Wait -PassThru -NoNewWindow
    return $p.ExitCode
}

Write-Host "Project Ascend: update and verify ($Repo)" -ForegroundColor Cyan

# 1. Pull.
if ($SkipPull) { Step "Pull from GitHub" "SKIPPED" "-SkipPull" }
else {
    $dirty = RepoGit status --porcelain
    if ($dirty) {
        Step "Pull from GitHub" "SKIPPED" "you have uncommitted changes; commit or stash them, then run again"
    } else {
        RepoGit fetch $Remote $Branch 2>&1 | Out-File (Join-Path $Out "git.log")
        $current = (RepoGit rev-parse --abbrev-ref HEAD).Trim()
        if ($current -ne $Branch) { RepoGit checkout $Branch 2>&1 | Out-File -Append (Join-Path $Out "git.log") }
        RepoGit merge --ff-only "$Remote/$Branch" 2>&1 | Out-File -Append (Join-Path $Out "git.log")
        if ($LASTEXITCODE -eq 0) { Step "Pull from GitHub" "OK" ("now at " + (RepoGit log --oneline -1)) }
        else { Step "Pull from GitHub" "FAILED" "not a fast-forward; see git.log" }
    }
}

# 2. Data and rules tests.
Push-Location $Repo
npm run build *> (Join-Path $Out "npm_build.log")
$npmExit = $LASTEXITCODE
Pop-Location
$passed = Select-String -Path (Join-Path $Out "npm_build.log") -Pattern "tests passed" | Select-Object -Last 1
if ($npmExit -eq 0) { Step "Data + rules tests" "OK" ($(if ($passed) { $passed.Line.Trim() } else { "" })) }
else { Step "Data + rules tests" "FAILED" "see npm_build.log" }

if (-not (Test-Path $Unity)) {
    Step "Unity" "SKIPPED" "Unity not found at $Unity (pass -Unity <path to Unity.exe>)"
} else {
    # 3. Scene.
    $code = RunUnity (Join-Path $Out "scene.log") @("-quit", "-executeMethod", "Ascend.EditorTools.Ring0SceneBuilder.BuildBatch")
    if ($code -eq 0) { Step "Rebuild Ring 0 scene" "OK" "" } else { Step "Rebuild Ring 0 scene" "FAILED" "exit $code; see scene.log" }

    # 4. PlayMode tests.
    $xml = Join-Path $Out "playmode.xml"
    $code = RunUnity (Join-Path $Out "playmode.log") @("-runTests", "-testPlatform", "PlayMode", "-testResults", $xml)
    if (Test-Path $xml) {
        $run = ([xml](Get-Content $xml -Raw)).'test-run'
        $detail = "$($run.passed) passed, $($run.failed) failed of $($run.total)"
        if ([int]$run.failed -gt 0) {
            $names = ([xml](Get-Content $xml -Raw)).SelectNodes("//test-case[@result='Failed']") | ForEach-Object { $_.name }
            $detail += " (" + ($names -join ", ") + ")"
        }
        Step "PlayMode tests" ($(if ([int]$run.failed -eq 0) { "OK" } else { "FAILED" })) $detail
    } else { Step "PlayMode tests" "FAILED" "exit $code, no results file; see playmode.log" }

    # 5. Player and screenshots.
    if ($SkipPlayer) { Step "Player build" "SKIPPED" "-SkipPlayer" }
    else {
        $code = RunUnity (Join-Path $Out "player.log") @("-quit", "-executeMethod", "Ascend.EditorTools.BuildPlayer.BuildRing0")
        $exe = Join-Path $Repo "Game/Builds/Ring0/ProjectAscend.exe"
        if ($code -eq 0 -and (Test-Path $exe)) {
            Step "Player build" "OK" $exe
            $shots = @(
                @{ Name = "01_plaza.png"; Args = @() },
                @{ Name = "02_plaza_south.png"; Args = @("-ascendShotAt", "0,2", "-ascendShotYaw", "180") },
                @{ Name = "10_labels_from_behind.png"; Args = @("-ascendShotAt", "4,4", "-ascendShotYaw", "200") }
            )
            foreach ($s in $shots) {
                $png = Join-Path $Out $s.Name
                $a = @("-screen-width", "1600", "-screen-height", "900", "-screen-fullscreen", "0", "-ascendShot", $png) + $s.Args
                Start-Process -FilePath $exe -ArgumentList $a -Wait -NoNewWindow
            }
            $made = (Get-ChildItem $Out -Filter *.png).Count
            Step "Screenshots" ($(if ($made -eq $shots.Count) { "OK" } else { "FAILED" })) "$made of $($shots.Count) in $Out"
        } else { Step "Player build" "FAILED" "exit $code; see player.log" }
    }
}

$summary = @("Project Ascend verify $Stamp") + ($Results | ForEach-Object { "{0,-8} {1,-24} {2}" -f $_.Status, $_.Step, $_.Detail })
$summary | Set-Content -Encoding UTF8 (Join-Path $Out "summary.txt")
Write-Host ""
$summary | ForEach-Object { Write-Host $_ }
Write-Host "Logs: $Out" -ForegroundColor Cyan
Write-Host "Check the scene diff before committing it: git -c safe.directory=$Safe diff --stat" -ForegroundColor Cyan
if ($Results.Status -contains "FAILED") { exit 1 } else { exit 0 }
