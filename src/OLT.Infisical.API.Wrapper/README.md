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

### API Endpoints

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

```csharp

public class InfisicalSecretService : IInfisicalSecretService
{
    private readonly OLT.Infisical.API.Wrapper.IInfisicalApiSecrets _infiscialSecretsApi;

    public InfisicalSecretService(OLT.Infisical.API.Wrapper.IInfisicalApiSecrets infiscialSecretsApi)
    {
        _infiscialSecretsApi = infiscialSecretsApi;
    }

    public async Task GetAllAsync(CancellationToken cancellationToken)
    {
        var query = new OLT.Infisical.API.Wrapper.Secrets.Query.InfisicalListSecretsQuery
        {
            WorkspaceId = "00000000-0000-0000-0000-000000001234",
            SecretPath = "/MyPath",
            Environment = "prod",
            Recursive = true,
            IncludeImports = true,
        };

        var queryResult = await _infiscialSecretsApi.ListSecrets(query, cancellationToken);

        foreach (var secret in queryResult.Secrets)
        {
            //Do Stuff
            Console.WriteLine(secret.SecretPath);
            Console.WriteLine(secret.SecretKey);
            Console.WriteLine(secret.SecretValue);
        }
    }

    public async Task<string> CreateSecretAsync(string path, string secretKey, string secretValue, InfisicalEnvironmentTypes environment, CancellationToken cancellationToken, int size)
    {
        var request = new OLT.Infisical.API.Wrapper.Secrets.Request.InfisicalCreateSecretRequest
        {
            WorkspaceId = _infisicalConnectionString.ProjectId!,
            Environment = environment.GetCodeEnum()!,
            SecretPath = path,
            SecretValue = secretValue,
        };

        var result = await _infiscialSecretsApi.CreateSecret(secretKey, request, cancellationToken);

        Console.Write(result.Secret?.Id);
    }
}

```

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


```csharp

public class InfisicalFolderService : IInfisicalFolderService
{
    private readonly OLT.Infisical.API.Wrapper.IInfisicalApiFolders _infiscialFoldersApi;

    public InfisicalSecretService(OLT.Infisical.API.Wrapper.IInfisicalApiFolders infiscialFoldersApi)
    {
        _infiscialFoldersApi = infiscialFoldersApi;
    }

    public async Task GetAllAsync(CancellationToken cancellationToken)
    {
        var query = new OLT.Infisical.API.Wrapper.Folders.Query.InfisicalListFoldersQuery
        {
            WorkspaceId = "00000000-0000-0000-0000-000000001234",
            Path = "/MyPath",
            Environment = "prod"
        };

        var queryResult = await _infiscialFoldersApi.ListFolders(query, cancellationToken);

        foreach (var folder in result.Folders)
        {
            //Do Stuff
            Console.WriteLine(folder.Id);
            Console.WriteLine(folder.Name);
        }
    }

    public async Task CreateAsync(CancellationToken cancellationToken)
    {
        var request = new OLT.Infisical.API.Wrapper.Folders.Requests.InfiscalCreateFolderRequest
        {
            WorkspaceId = "00000000-0000-0000-0000-000000001234",
            Environment = "prod",
            Path = "/MyPath",            
            Name = "NewFolderName"
        };

        var createFolderResult = await _infiscialFoldersApi.CreateFolder(request, cancellationToken);

        Console.WriteLine(createFolderResult.Folder.Id);
        Console.WriteLine(createFolderResult.Folder.Name);
    }
}

```