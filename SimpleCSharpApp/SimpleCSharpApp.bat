@echo off
rem A batch file for SimpleCSharpApp.exe
rem which captures the app's return value.

.\SimpleCSharpApp\bin\debug\SimpleCSharpApp
@if "%ERRORLEVEL%" == "0" goto success

:fail
  echo This application has failed!
  echo return value was %ERRORLEVEL%
  goto end

:success
  echo This application has succeeded!
  echo return value was %ERRORLEVEL%
  goto end

:end
echo All Done.
