### PREPARE
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src

### Copy csproj and sln and restore as distinct layers
COPY Common/Common.ApiClient/*.csproj Common/Common.ApiClient/
COPY Common/Common.Application/*.csproj Common/Common.Application/
COPY Common/Common.Domain/*.csproj Common/Common.Domain/
COPY Common/Common.Extensions/*.csproj Common/Common.Extensions/
COPY Core.Application/*.csproj Core.Application/
COPY Core.Domain/*.csproj Core.Domain/
COPY Infrastructure.Persistence/*.csproj Infrastructure.Persistence/
COPY Presentation.Api.WebApi/*.csproj Presentation.Api.WebApi/
COPY Presentation.Shared.Rcl/*.csproj Presentation.Shared.Rcl/
COPY Presentation.Web.BlazorServer/*.csproj Presentation.Web.BlazorServer/
COPY Presentation.Web.BlazorStatic/*.csproj Presentation.Web.BlazorStatic/
COPY Goodtocode.Subjects.sln .
RUN dotnet restore

### PUBLISH
FROM build-env as publish-env
COPY . .
RUN dotnet publish "Goodtocode.Subjects.sln" -c Release -o /app/out

### RUNTIME IMAGE
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime-env
WORKDIR /app/out
COPY --from=publish-env /app/out .

ENV ASPNETCORE_URLS=http://+:30001
EXPOSE 30001

ENV ASPNETCORE_URLS=http://+:30002
EXPOSE 30002
ENTRYPOINT ["dotnet", "Goodtocode.Subjects.WebApi.dll", "--urls", "http://*:30002", "Goodtocode.Subjects.BlazorServer.dll", "--urls", "http://*:30001"]