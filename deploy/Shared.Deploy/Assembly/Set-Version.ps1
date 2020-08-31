# ***
# *** Parameters
# ***
param
(
	[Parameter(Mandatory=$true,ValueFromPipelineByPropertyName=$true)]
    [string] $Path= $(throw '-Path is a required parameter. $(Build.SourcesDirectory)'),
	[Version] $VersionToReplace = "5.20.1",
	[string] $Format = 'M.YY.MM'	
)

# ***
# *** Initialize
# ***
Set-ExecutionPolicy Unrestricted -Scope Process -Force
$VerbosePreference = 'SilentlyContinue' # 'Continue'
[String]$ThisScript = $MyInvocation.MyCommand.Path
[String]$ThisDir = Split-Path $ThisScript
[DateTime]$Now = Get-Date
Set-Location $ThisDir # Ensure our location is correct, so we can use relative paths
Write-Host "*****************************"
Write-Host "*** Starting: $ThisScript on $Now"
Write-Host "*****************************"
# Imports
Import-Module "..\Dependencies\GoodToCode.Code.psm1"
Import-Module "..\Dependencies\GoodToCode.System.psm1"

# ***
# *** Validate and cleanse
# ***
$Path = Set-Unc -Path $Path

# ***
# *** Locals
# ***

# ***
# *** Execute
# ***
$Year = get-date –format yy
[String]$Major = $VersionToReplace.Major.ToString()
[String]$Minor = $VersionToReplace.Minor.ToString()
[String]$Revision = $VersionToReplace.Revision.ToString()
[String]$Build = $VersionToReplace.Build.ToString()

$Major = $Major.ToString().Replace('-1', '1')
$Minor = $Minor.ToString().Replace('-1', $Year)
$Revision = $Revision.ToString().Replace('-1', '')
$Build = $Build.ToString().Replace('-1', '')

Write-Host "Set-Version -Path $Path -Version $VersionToReplace"
# .Net Projects
$LongVersion = Get-Version -Major $Major -Minor $Minor -Revision $Revision -Build $Build
$ShortVersion = Get-Version -Major $Major -Minor $Minor -Revision $Revision -Format $Format
Write-Host 
Update-ContentsByTag -Path $Path -Value $LongVersion -Open '<Version>' -Close '</Version>' -Include *.csproj
Update-ContentsByTag -Path $Path -Value $LongVersion -Open '<version>' -Close '</version>' -Include *.nuspec
Update-LineByContains -Path $Path -Contains "AssemblyVersion(" -Line "[assembly: AssemblyVersion(""$LongVersion"")]" -Include AssemblyInfo.cs
# Vsix Templates
Update-TextByContains -Path $Path -Contains "<Identity Id" -Old $VersionToReplace -New $ShortVersion -Include *.vsixmanifest