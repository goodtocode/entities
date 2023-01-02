// =========== /.azure/main.bicep ===========
targetScope = 'subscription'

param location string = deployment().location

resource rg 'Microsoft.Resources/resourceGroups@2021-01-01' = {
  name: 'gtc-rg-entities-dev-001'
  location: westus3
}