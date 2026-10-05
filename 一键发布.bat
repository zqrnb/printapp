@echo off
setlocal

REM ============================================================
REM  PrintCodeBtapp - one-click publish (run on the BUILD machine)
REM  Usage: double-click, or pass an output directory as %1
REM  Output: portable no-install folder (framework-dependent)
REM ============================================================

set "SLN_ROOT=%~dp0"
set "CSPROJ=%SLN_ROOT%PrintCodeBtapp\PrintCodeBtapp.csproj"
set "ICON=bitbug_favicon1.ico"

REM ---- output dir: default is sibling of this repo; override via %1 ----
if "%~1"=="" (
    set "OUTDIR=%SLN_ROOT%..\PrintCodeBtapp-Publish"
) else (
    set "OUTDIR=%~1"
)

echo [1/3] Checking icon file...
if exist "%SLN_ROOT%PrintCodeBtapp\%ICON%" (
    echo     Found: %ICON%
) else (
    echo     [ERROR] %ICON% not found in the PrintCodeBtapp folder.
    pause
    exit /b 1
)

echo [2/3] Publishing (framework-dependent, no -r on purpose)...
dotnet publish "%CSPROJ%" -c Release --self-contained false -o "%OUTDIR%"
if errorlevel 1 (
    echo     [ERROR] Publish failed. Is the dotnet SDK installed?
    pause
    exit /b 1
)

echo.
echo [3/3] Bundling the shortcut script into the output folder...
copy /y "%~dp0CreateShortcut.bat" "%OUTDIR%\" >nul

echo.
echo Done! Output folder: %OUTDIR%
echo.
echo Deploy on the target machine:
echo   1. Copy the whole output folder to the industrial PC;
echo   2. Put barcode.btw and the preview-image folder into the program dir;
echo   3. Double-click "CreateShortcut.bat" inside that folder.
pause
