@echo off

set PROJECT=%~1
set TASK=%~2
set TARGET_FRAMEWORK=net7.0

set IS_HELP=false
if "%PROJECT%"=="" set IS_HELP=true
if "%PROJECT%"=="help" set IS_HELP=true

if %IS_HELP%==true (
  call :help
  exit /b
)

set OUTPUT=%CD%
set CONTEST_TYPE=%PROJECT:~0,3%
echo %CONTEST_TYPE% | findstr /r "A[BGR]C" > nul

if %ERRORLEVEL%==0 (
  set OUTPUT=%CD%\%CONTEST_TYPE%
) else (
  set OUTPUT=%CD%\Other
)

if not exist %OUTPUT% (
  echo Create %OUTPUT%.
  mkdir %OUTPUT%
)

set PROJECT_PATH=%OUTPUT%\%PROJECT%

if "%TASK%"=="" (
  call :project %PROJECT_PATH% %PROJECT%
) else (
  call :task %PROJECT_PATH% %TASK%
)

exit /b

:help
  echo Usage: atcoder.cmd [project-name]                Create a new project.
  echo Usage: atcoder.cmd [project-name] [task-name]    Create a new task to the project.
  exit /b

:task
  setlocal
  set PROJECT_PATH=%~1
  set TASK=%~2
  set OUTPUT_FILE=%PROJECT_PATH%\%TASK%.cs

  if exist %OUTPUT_FILE% (
    echo %OUTPUT_FILE% is already exist. Skip creating the file.
    exit /b
  )

  echo Create %OUTPUT_FILE%.
  call dotnet new cpsolver -n %TASK% -o %PROJECT_PATH%
  call code -n . %OUTPUT_FILE%

  endlocal
  exit /b

:project
  setlocal
  set PROJECT_PATH=%~1
  set PROJECT=%~2

  if exist %PROJECT_PATH% (
    echo %PROJECT_PATH% is already exist. Skip creating the project.
    exit /b
  )

  echo Create %PROJECT% to %PROJECT_PATH%.
  call dotnet new cpproj -n %PROJECT% -f %TARGET_FRAMEWORK% -o %PROJECT_PATH%
  call code -n . .vscode\settings.json %PROJECT_PATH%\%PROJECT%.csproj %PROJECT_PATH%\Tests.cs

  setlocal enabledelayedexpansion
  for %%p in (A B C D E F) do (
    call :task !PROJECT_PATH! %%p
  )
  endlocal

  start https://atcoder.jp/contests/%PROJECT%
  endlocal
  exit /b
