@echo off

set TEMPLATEVERSION=1.0.0

powershell -Command "Invoke-WebRequest -Uri https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases/download/v%TEMPLATEVERSION%/AconCavy.CompetitiveProgramming.Templates.%TEMPLATEVERSION%.nupkg -OutFile ./tmp/AconCavy.CompetitiveProgramming.Templates.%TEMPLATEVERSION%.nupkg; dotnet new -i ./tmp/AconCavy.CompetitiveProgramming.Templates.%TEMPLATEVERSION%.nupkg"