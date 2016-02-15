@echo off
setlocal

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

:: Push the packages
set "bin=%~dp0artifacts\bin"
cd "%bin%"
for /d %%d in (*) do (
    cd "%%d\Release"
    del /q *.symbols.nupkg
    "%nuget%" push *.nupkg
    del /q *.nupkg > nul
    cd "%bin%"
)
