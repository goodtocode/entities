# GoodToCode Stack

GoodToCode Stack is a Microservice/Serverless centric collection of common Domain Entities that you often include in software applications. These Entities, like Person and Location, can be assembled and used in your business apps and APIs.
The goal of the GoodToCode Stack is to quick-start custom software applications by providing easy-to-extend Domain Entities and the APIs/Azure Functions that exposes these entities.

GoodToCode Stack is based on DDD, onion-architecture, vertical slice and CQRS in .NET Core and EF Core code-first.

## Installation
### Environment Variables
1. Create "AzureSettingConnection" (required)
* Go to portal.azure.com
* Create or find your Azure App Configuration service connection string

    Powershell: $env:AzureSettingConnection="Endpoint=https://{Your-Endpoint}.azconfig.io;Id={Your-Key}"
    
2. Create "ASPNETCORE_ENVIRONMENT" (optional, defaults to "Production")
* Local
* Development
* Production

    Powershell: $env:ASPNETCORE_ENVIRONMENT="Development"

### Azure App Configuration
1. Go to portal.azure.com
2. Create or find your Azure App Configuration service 
3. Add the following keys, with value from your Azure resources:
* Stack:Chronology:ApiUrl - {Your-ApiService-Url} - text/plain
* Stack:Chronology:FunctionsCode - {Your-FunctionApp-AppKey} - text/plain
* Stack:Chronology:FunctionsUrl - {Your-FunctionApp-Url} - text/plain
* Stack:Locality:ApiUrl - {Your-ApiService-Url} - text/plain
* Stack:Locality:FunctionsCode - {Your-FunctionApp-AppKey} - text/plain
* Stack:Locality:FunctionsUrl - {Your-FunctionApp-Url} - text/plain
* Stack:Occurrences:ApiUrl - {Your-ApiService-Url} - text/plain
* Stack:Occurrences:FunctionsCode - {Your-FunctionApp-AppKey} - text/plain
* Stack:Occurrences:FunctionsUrl - {Your-FunctionApp-Url} - text/plain
* Stack:Shared:Sentinel - 1 - text/plain
* Stack:Shared:SqlConnection - {Your-AzureSql-ConnectionString} - text/plain
* Stack:Subjects:ApiUrl - {Your-ApiService-Url} - text/plain
* Stack:Subjects:FunctionsCode - {Your-FunctionApp-AppKey} - text/plain
* Stack:Subjects:FunctionsUrl - {Your-FunctionApp-Url} - text/plain

## Namespaces
### GoodToCode.Chronology
Includes all Domain Models for any chronological entity such as: Schedules (Schedule entity) and Hours of Operations (TimeRecurring entity)

### GoodToCode.Locality
Includes all Domain Models for any locale-centric entity such as: Locations (Location entity) and LatLongs (LatLong entity)

### GoodToCode.Subjects
Includes all Domain Models for any subject entity such as: People (Person entity) and Businesses (Business entity)

### GoodToCode.Occurrences
Includes all Domain Models for any occurnce of one or more Chronology + Locality + Subject entities such as: Events (Event entity) and Appointments (Appointment entity)

### GoodToCode.Shared
Shared kernel on which all projects depend. Primary aspect is GoodToCode.Stack.Abstractions, which allows external applications to code to abstractions of the stack.

## Projects
### GoodToCode.Presentation.Api: 
ASP.NET Web API endpoints exposing that vertical's Application Service

### GoodToCode.Presentation.Functions: 
Azure Functions HTTP endpoints exposing that vertical's Application Service

### GoodToCode.Application.Services: 
CQRS Commands and Queries that call aggregate roots.

### GoodToCode.Domain.Models: 
Domain aggregates and domain models

### GoodToCode.Infrastructure.Persistence: 
EF Core code first persistence layer for SQL Server, CosmosDb, Azure Storage Tables and PosgreSQL

Disclaimer: This work is under development mostly for internal projects, and is still highly volatile. Watch for any Releases, which will include tested and hardened versions.

