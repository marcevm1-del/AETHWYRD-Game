// Runs the C# rules tests (Code/Ascend.Core.Tests) with whichever .NET 8 SDK is available:
// the system `dotnet` if it has an SDK, otherwise the SDK bundled with the Unity editor.
// Usage: npm test
const { execFileSync, spawnSync } = require('child_process');
const fs = require('fs');
const path = require('path');

const ROOT = path.join(__dirname, '..');
const candidates = ['dotnet', 'E:/Unity/Editors/6000.6.7f1/Editor/Data/DotNetSdk/dotnet.exe', 'E:/6000.6.7f1/Editor/Data/DotNetSdk/dotnet.exe', process.env.ASCEND_DOTNET].filter(Boolean);

function hasSdk(exe) {
  try { return execFileSync(exe, ['--list-sdks'], { encoding: 'utf8' }).trim().length > 0; } catch { return false; }
}
const dotnet = candidates.find(c => (c === 'dotnet' || fs.existsSync(c)) && hasSdk(c));
if (!dotnet) {
  console.error('No .NET SDK found. Install the .NET 8 SDK, or set ASCEND_DOTNET to a dotnet.exe that has one.');
  process.exit(1);
}
const r = spawnSync(dotnet, ['run', '--project', path.join(ROOT, 'Code', 'Ascend.Core.Tests')], {
  stdio: 'inherit',
  env: { ...process.env, DOTNET_CLI_TELEMETRY_OPTOUT: '1', DOTNET_NOLOGO: '1', DOTNET_SKIP_FIRST_TIME_EXPERIENCE: '1' }
});
process.exit(r.status ?? 1);
