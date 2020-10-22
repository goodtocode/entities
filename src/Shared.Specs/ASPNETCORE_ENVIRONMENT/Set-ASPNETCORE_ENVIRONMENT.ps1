# ***
# *** Parameters
# ***
param
(
	[Parameter(Mandatory=$true,ValueFromPipelineByPropertyName=$true)]
    [string] $Environment=$(throw '-Environment is a required parameter. Default is Production')
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

# ***
# *** Execute
# ***
# Set Machine - Requires Admin
#[Environment]::SetEnvironmentVariable($Environment, $env:ASPNETCORE_ENVIRONMENT, [System.EnvironmentVariableTarget]::Machine)

# Set User
# [Environment]::SetEnvironmentVariable($Environment, $env:ASPNETCORE_ENVIRONMENT, [System.EnvironmentVariableTarget]::User)

# Shortcut method
$env:ASPNETCORE_ENVIRONMENT = $Environment

# Verify
gci env:ASPNETCORE_ENVIRONMENT