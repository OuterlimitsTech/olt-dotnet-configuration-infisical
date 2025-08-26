# OLT.Infisical.API.Wrapper - Wrapper for Infisical API

A .NET API wrapper for Infisical's secrets management endpoints. This library provides strongly-typed interfaces for interacting with Infisical's REST API, including secret creation, update, deletion, retrieval, bulk operations, and tag management.


[![Nuget](https://img.shields.io/nuget/v/OLT.Extensions.Configuration.Infisical)](https://www.nuget.org/packages/OLT.Extensions.Configuration.Infisical)

[![CI](https://github.com/OuterlimitsTech/olt-dotnet-configuration-infisical/actions/workflows/build.yml/badge.svg)](https://github.com/OuterlimitsTech/olt-dotnet-configuration-infisical/actions/workflows/build.yml) 

### Install the package:
```shell
dotnet add package OLT.Infisical.API.Wrapper
```



## Secrets

- Create, update, delete, and retrieve secrets
- Bulk operations for secrets (create, update, delete)
- Attach and detach tags to secrets
- Query secrets with advanced filtering
- Fully async API using `Task`
- Designed for .NET 8 and .NET 9
- Uses [Refit](https://github.com/reactiveui/refit) for declarative REST API calls

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

### Documentation

- [Infisical API Reference](https://infisical.com/docs/api-reference/overview/introduction)

### Contributing

Pull requests and issues are welcome.


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

### Get Secrets
```csharp
using OLT.Infisical.API.Wrapper;


services.AddInfisicalHttpClient(opts =>
{
    // opts.SiteUrl = "https://infisical.mydomain.com";  <-- Custom URL if needed (default is https://us.infisical.com)
    opts.ClientId = "00000000-0000-0000-0000-000000000000";
    opts.ClientSecret = "client secret here";
});

```

## Folders

## Supported Endpoints

- **Create Folder**: `POST /api/v3/folders`
- **Update Folder**: `PATCH /api/v3/folders/{folderName}`
- **Delete Folder**: `DELETE /api/v3/folders/{folderName}`
- **Get Folder by ID**: `GET /api/v3/folders/{id}`
- **List Folders**: `GET /api/v3/folders`

## Usage

1. **Install Refit**  
   Add the [Refit](https://github.com/reactiveui/refit) NuGet package to your project.

2. **Define the API Client**