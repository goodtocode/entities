# GoodToCode Entities
<sup>The goal of GoodToCode Entities is to quick-start custom software applications by providing easy-to-extend Domain Entities and the APIs/Azure Functions that exposes these entities.</sup>

![Entities LZ](https://github.com/goodtocode/entities/actions/workflows/gtc-rg-entities-landingzone.yml/badge.svg)

![Subjects LZ](https://github.com/goodtocode/entities/actions/workflows/gtc-rg-subjects-landingzone.yml/badge.svg)

![Subjects API](https://github.com/goodtocode/entities/actions/workflows/gtc-rg-chronology-landingzone.yml/badge.svg)

GoodToCode Entities is a Microservice/Serverless centric collection of common Domain Entities that you often include in software applications. These Entities, like Person and Location, can be assembled and used in your business apps and APIs.

GoodToCode Entities is based on DDD, onion-architecture, vertical slice and CQRS in .NET Core and EF Core code-first.

## Installation
### Environment Variables
1. Create "ASPNETCORE_ENVIRONMENT" and set it to Development. These relate to the appsettings.ENVIRONMENT.json files.
* Development
* Production

    Powershell: $env:ASPNETCORE_ENVIRONMENT="Development"

### Azure Infrastructure as Code (IaC)
#### Create a Cloud Adoption Framework (CAF) Landing Zone

[About CAF Landing Zones](https://learn.microsoft.com/en-us/azure/cloud-adoption-framework/ready/landing-zone/)
1. If you are using GitHub Actions
* Create the shared Entities resource group: .github/workflows/gtc-rg-entities-landingzone.yml
* Create the Subjects resource group: .github/workflows/gtc-rg-subjects-landingzone.yml
* Deploy the Subjects API and runs EF Migrations: .github/workflows/gtc-rg-subjects-api.yml

2. If you are using Azure DevOps Pipelines
* Create the shared Entities resource group: .azure-devops/pipelines/gtc-entities-landingzone.yml
* Create the Subjects resource group: .azure-devops/pipelines/gtc-entities-subjects-landingzone.yml
* Deploy the Subjects API: .azure-devops/pipelines/gtc-entities-subjects-api.yml
* Deploy the Subjects EF Migrations: .azure-devops/pipelines/gtc-entities-subjects-ef.yml

## Projects and Namespaces
Namespace | Path | Contents
--- | --- | ---
Goodtocode.Subjects.Common | /src/Subjects/Common | Includes shared kernel library that are candidates to share with other projects.
Goodtocode.Subjects.Domain | /src/Subjects/Core/Domain | Includes core domain objects, entities and interfaces. This only references .NET.
Goodtocode.Subjects.Application | /src/Subjects/Core/Application | Includes core application commands and queries. This only references Domain.
Goodtocode.Subjects.Persistence | /src/Subjects/Infrastructure/Persistence |Includes infrastructure concerns such as repositories, dbcontexts. This references Domain and Application.
Goodtocode.Subjects.WebApi | /src/Subjects/Common | Includes presentation Web API. This references Persistence.
Goodtocode.Subjects.Unit | /src/Subjects/Specs/Application.Unit | Unit tests that exercise Domain and Applicaiton with mocked infrastructure. This references Persistence.
Goodtocode.Subjects.Integration | /src/Subjects/Specs/Application.Integration | Unit tests that exercise Domain, Application and Presistence. Uses In-memory Database. This references Persistence.

