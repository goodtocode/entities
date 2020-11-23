REM Ignore the junk char, darn bugs
ECHO OFF
set connectionString=%1
IF %connectionString%.==. set connectionString=%StackSqlConnection%
ECHO ON

Echo ***
Echo Drop and create database with DbContext
Echo Pre-reqs: 
Echo   1. IP access to DB. 
Echo   2. DbContext.cs parameterless constructor 
Echo   3. .NET Core only, csproj must be TargetFramework-netcoreapp3.1

set workingDir=%~dp0
set workingDrive=%workingDir:~0,2%
%workingDrive%
cd %workingDir%
cd ..\

dotnet ef database drop --force
REM Create new Azure DB

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

set ConnectionStrings:MyDbConnection=%connectionString%

rd Migrations /s/q
dotnet ef migrations add InitialCreate
dotnet ef database update InitialCreate

