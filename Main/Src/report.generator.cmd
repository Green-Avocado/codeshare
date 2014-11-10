echo off

@REM author: mario.moreno@globant.com

echo report generator script

pushd %~dp0
set start_time=%time%
set reportgenerator_bin=..\tool\report.generator\ReportGenerator.exe
set opencover_file=%CD%\opencover.xml
set target_dir=.\coverage.report

@REM  ------------------------------------------------
@REM  Shorten the command prompt for making the output
@REM  easier to read.
@REM  ------------------------------------------------
set savedPrompt=%prompt%
set prompt=$$$g$s

IF NOT EXIST coverage.report\NUL GOTO NoCoverageReport
rmdir /s /q coverage.report
:NoCoverageReport
md coverage.report

%reportgenerator_bin% -reports:%opencover_file% -targetdir:%target_dir% -reporttypes:Html
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