@echo off
setlocal

set "config=Debug"
set "platform=Any CPU"

:arg_loop
if "%~1" == "" goto args_done

if /i "%~1" == "-?" goto usage
if /i "%~1" == "-h" goto usage
if /i "%~1" == "--help" goto usage

if /i "%~1" == "-c" (
    set "config=%~2"
    shift
)

if /i "%~1" == "--config" (
    set "config=%~2"
    shift
)

if /i "%~1" == "-p" (
    set "config=%~2"
    shift
)

if /i "%~1" == "--platform" (
    set "config=%~2"
    shift
)

shift
goto arg_loop

:usage
echo Usage:
echo ./build.cmd [option]...
echo.
echo Options:
echo -c,--config [Debug^|Release]        Set the configuration to Debug or Release (default is Release)
echo -p,--platform [Any CPU^|x86^|x64^|ARM] Build binaries for a particular platform (default is Any CPU)

goto :eof

:args_done

cd "%~dp0"
cmd /c dnu restore
msbuild /p:Configuration="%config%" /p:Platform="%platform%"
