@echo off
setlocal

:: Parse arguments
:arg_loop

if "%~1" == "" goto args_done

if /i "%~1" == "-h" goto usage
if /i "%~1" == "-?" goto usage
if /i "%~1" == "--help" goto usage

if /i "%~1" == "-v" (
    set "version=%~2"
    shift
)

if /i "%~1" == "--version" (
    set "version=%~2"
    shift
)

shift
goto arg_loop

:usage

echo Usage:
echo ./publish [option]...
echo.
echo Options:
echo -v,--version VERSION        Set the package's version to VERSION

goto :eof

:args_done

:: Version is required
if not defined version goto usage

:: Restore NuGet
set "nugetdir=%~dp0bin"
set "nuget=%nugetdir%\nuget.exe"
:: Use v3 of the command line util, since v2 is still unable to work with PCLs
set "nugeturl=http://dist.nuget.org/win-x86-commandline/latest/nuget.exe"

if not exist "%nuget%" (
    echo Restoring NuGet...
    if not exist "%nugetdir%" mkdir "%nugetdir%"
    powershell "iwr %nugeturl% -OutFile %nuget%"
)

:: Build the solution
call "%~dp0build.cmd" -p "Any CPU" -c Release

:: Create the package
cd "%~dp0src"
del /q *.nupkg > nul 2>&1
"%nuget%" pack Typed.Xaml.nuspec -Prop Version=%version%
"%nuget%" push *.nupkg
del /q *.nupkg > nul
