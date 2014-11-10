echo off

@REM author: mario.moreno@globant.com

echo vstest console script

pushd %~dp0
set start_time=%time%
set msbuild_bin=%PROGRAMFILES(X86)%\MSBuild\12.0\Bin\MSBuild.exe
set working_directory=%CD%
set vstestconsole_bin=%PROGRAMFILES(X86)%\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe

@REM  ------------------------------------------------
@REM  Shorten the command prompt for making the output
@REM  easier to read.
@REM  ------------------------------------------------
set savedPrompt=%prompt%
set prompt=$$$g$s

"%msbuild_bin%" vstestconsole.proj /p:WorkingDirectory="%working_directory%" /p:VSTestConsoleBinPath="%vstestconsole_bin%"
@if %errorlevel% NEQ 0 goto error
goto success

:error
echo an error has occurred.
GOTO finish

:success
echo process successfully finished.
echo start time: %start_time%
echo end time: %Time%

:finish
popd
set prompt=%savedPrompt%

echo on