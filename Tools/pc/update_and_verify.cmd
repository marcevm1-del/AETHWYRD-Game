@echo off
rem Double-click: pull the latest main from GitHub, then run every check (data, rules, scene, PlayMode, player, screenshots).
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0update_and_verify.ps1" %*
echo.
pause
