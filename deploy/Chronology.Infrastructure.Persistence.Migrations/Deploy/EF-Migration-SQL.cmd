REM Ignore the junk char, darn bugs
ECHO OFF
set connectionString=%1
IF %connectionString%.==. set connectionString=%StackSqlConnection%
ECHO ON

Echo ***
Echo Update database with DbContext (changes and additions, no drops)
Echo Pre-reqs: 
Echo   1. IP access to DB. 
Echo   2. DbContext.cs parameterless constructor 
Echo   3. .NET Core only, csproj must be TargetFramework-netcoreapp3.1

set workingDir=%~dp0
set workingDrive=%workingDir:~0,2%
%workingDrive%
cd %workingDir%
cd ..\

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

set ConnectionStrings:MyDbConnection=%connectionString%

ECHO OFF
REM YYYYMMDD-HHMMSS
set CUR_YYYY=%date:~10,4%
set CUR_MM=%date:~4,2%
set CUR_DD=%date:~7,2%
set CUR_HH=%time:~0,2%
if %CUR_HH% lss 10 (set CUR_HH=0%time:~1,1%)
set CUR_NN=%time:~3,2%
set CUR_SS=%time:~6,2%
set CUR_MS=%time:~9,2%
set TimeDate=%CUR_YYYY%%CUR_MM%%CUR_DD%-%CUR_HH%%CUR_NN%%CUR_SS%
ECHO ON

dotnet ef migrations script --no-build --idempotent --output migration.sql --context ChronologyDbContextDeploy --verbose

REM SET XACT ABORT ON
REM BEGIN TRANSACTION
REM :r $(System.DefaultWorkingDirectory)\drop\migration.sql
REM IF @@TRANCOUNT > 0 COMMIT