@echo off
setlocal

REM ============================================================
REM  PrintCodeBtapp - create desktop shortcut (run on the TARGET machine)
REM  Usage1: double-click this script (put it in the publish folder)
REM  Usage2: drag PrintCodeBtapp.exe onto this script
REM  The shortcut name comes from the exe's ProductName (Chinese ok).
REM ============================================================

if "%~1"=="" (set "EXE=") else set "EXE=%~1"

REM auto-detect exe next to this script if no file was dropped on it
if not defined EXE if exist "%~dp0PrintCodeBtapp.exe" set "EXE=%~dp0PrintCodeBtapp.exe"

if not defined EXE goto usage
if not exist "%EXE%" goto notfound

set "PRINTEXE=%EXE%"

powershell -NoProfile -ExecutionPolicy Bypass -Command "$exe=$env:PRINTEXE; $n=[System.Diagnostics.FileVersionInfo]::GetVersionInfo($exe).ProductName; if([string]::IsNullOrWhiteSpace($n)){$n='PrintCodeBtapp'}; $d=[Environment]::GetFolderPath('Desktop'); $lnk=Join-Path $d ($n+'.lnk'); $ws=New-Object -ComObject WScript.Shell; $s=$ws.CreateShortcut($lnk); $s.TargetPath=$exe; $s.WorkingDirectory=(Split-Path $exe); $s.IconLocation=($exe+',0'); $s.Save(); Write-Host ('OK - shortcut: '+$lnk)"

if errorlevel 1 goto fail
echo Done. Shortcut created on the Desktop.
pause
exit /b 0

:usage
echo Drag PrintCodeBtapp.exe onto this script, or put this script in
echo the publish folder next to the exe and double-click it.
pause
exit /b 1

:notfound
echo File not found: %EXE%
pause
exit /b 1

:fail
echo Failed to create the shortcut.
pause
exit /b 1
