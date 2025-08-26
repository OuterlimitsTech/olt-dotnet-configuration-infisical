# OLT.Infisical.API.Wrapper - Wrapper for Infisical API

A .NET API wrapper for Infisical's secrets management endpoints. This library provides strongly-typed interfaces for interacting with Infisical's REST API, including secret creation, update, deletion, retrieval, bulk operations, and tag management.


[![Nuget](https://img.shields.io/nuget/v/OLT.Extensions.Configuration.Infisical)](https://www.nuget.org/packages/OLT.Extensions.Configuration.Infisical)

[![CI](https://github.com/OuterlimitsTech/olt-dotnet-configuration-infisical/actions/workflows/build.yml/badge.svg)](https://github.com/OuterlimitsTech/olt-dotnet-configuration-infisical/actions/workflows/build.yml) 

### Install the package:
```shell
dotnet add package OLT.Infisical.API.Wrapper
```

### Overview

- Fully async API using `Task`
- Designed for .NET 8 and .NET 9
- Uses [Refit](https://github.com/reactiveui/refit) for declarative REST API calls

- 
#### Add the Infisical HTTP Client to your service collection:

```csharp
using OLT.Infisical.API.Wrapper;


services.AddInfisicalHttpClient(opts =>
{
    // opts.SiteUrl = "https://infisical.mydomain.com";  <-- Custom URL if needed (default is https://us.infisical.com)
    opts.ClientId = "00000000-0000-0000-0000-000000000000";
    opts.ClientSecret = "client secret here";
});

```


## Secrets

- Create, update, delete, and retrieve secrets
- Bulk operations for secrets (create, update, delete)
- Attach and detach tags to secrets
- Query secrets with advanced filtering


### Usage

- `CreateSecret` - Create a new secret
- `UpdateSecret` - Update an existing secret
- `DeleteSecret` - Delete a secret
- `RetrieveSecret` - Get a secret by name
- `ListSecrets` - List all secrets
- `BulkCreate` - Create multiple secrets
- `BulkUpdate` - Update multiple secrets
- `BulkDelete` - Delete multiple secrets
- `AttachTags` - Attach tags to a secret
- `DetachTags` - Detach tags from a secret

## API Endpoints

| Method        | Verb   | Endpoint                            | Description                |
|---------------|--------|-------------------------------------|----------------------------|
| CreateSecret  | POST   | /api/v3/secrets/raw/{secretName}    | Create a secret            |
| UpdateSecret  | PATCH  | /api/v3/secrets/raw/{secretName}    | Update a secret            |
| DeleteSecret  | DELETE | /api/v3/secrets/raw/{secretName}    | Delete a secret            |
| RetrieveSecret| GET    | /api/v3/secrets/raw/{secretName}    | Retrieve a secret          |
| ListSecrets   | GET    | /api/v3/secrets/raw                 | List secrets               |
| BulkUpdate    | PATCH  | /api/v3/secrets/batch/raw           | Bulk update secrets        |
| BulkCreate    | POST   | /api/v3/secrets/batch/raw           | Bulk create secrets        |
| BulkDelete    | DELETE | /api/v3/secrets/batch/raw           | Bulk delete secrets        |
| AttachTags    | POST   | /api/v3/secrets/tags/{secretName}   | Attach tags to a secret    |
| DetachTags    | DELETE | /api/v3/secrets/tags/{secretName}   | Detach tags from a secret  |


## Folders

- Create, update, delete, and retrieve folders
- Query folders with advanced filtering


### Usage 

- `CreateFolder` - Create a new folder
- `UpdateFolder` - Update a folder
- `DeleteFolder` - Delete a folder
- `GetFolder` - Get folder by id
- `ListFolders` - List all folders


### API Endpoints

| Method         | Verb   | Endpoint                     | Description            |
|----------------|--------|------------------------------|------------------------|
| CreateFolder   | POST   | /api/v3/folders              | Create a folder        |
| UpdateFolder   | PATCH  | /api/v3/folders/{folderName} | Update a folder        |
| DeleteFolder   | DELETE | /api/v3/folders/{folderName} | Delete a folder        |
| GetFolderByID  | GET    | /api/v3/folders/{id}         | Get folder by ID       |
| ListFolders    | GET    | /api/v3/folders              | List folders           |
