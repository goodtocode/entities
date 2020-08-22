REM Ignore the junk char, darn bugs
ECHO OFF
set connectionString=%1
IF %connectionString%.==. set connectionString="Server=tcp:goodtocodestack.database.windows.net,1433;Initial Catalog=StackData;Persist Security Info=False;User ID=LocalAdmin;Password=1202cc89-cb6f-453a-ac7e-550b3b5d2d0c;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
ECHO ON

Echo ***
Echo Drop and create database with DbContext
Echo Pre-reqs: 
Echo   1. IP access to DB. 
Echo   2. DbContext.cs parameterless constructor 
Echo   3. .NET Core only, csproj must be TargetFramework-netcoreapp3.1

cd %~dp0
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef

set ConnectionStrings:MyDbConnection=%connectionString%

rd Migrations /s/q
dotnet ef migrations add InitialCreate
dotnet ef database update InitialCreate

