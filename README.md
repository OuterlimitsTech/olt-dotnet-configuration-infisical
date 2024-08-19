# .NET Configuration Extensions for Infisical 

## OLT.Extensions.Configuration.Infisical is a configuration provider for the .NET Core that allows developers to use [Infisical(https://infisical.com/)] as a configuration source in their applications.

[![Nuget](https://img.shields.io/nuget/v/OLT.Extensions.Configuration.Infisical)](https://www.nuget.org/packages/OLT.Extensions.Configuration.Infisical)

[![CI](https://github.com/OuterlimitsTech/olt-dotnet-configuration-infisical/actions/workflows/build.yml/badge.svg)](https://github.com/OuterlimitsTech/olt-dotnet-configuration-infisical/actions/workflows/build.yml) 

### Install the package:

```shell
dotnet add package OLT.Extensions.Configuration.Infisical
```

### Simple

```csharp
using OLT.Extensions.Configuration.Infisical;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddInfisical(options, "E2BCF5B2-0000-0000-0000-000000009876", "---ClientSecret---", "47C230B4-0000-0000-0000-000000001234", "prod", false, TimeSpan.FromMinutes(10));

```


### Load all secrets and all subfolders

```csharp
using OLT.Extensions.Configuration.Infisical;

var options = new InfisicalOptions
{
    ClientId = "E2BCF5B2-0000-0000-0000-000000009876",
    ClientSecret = "---ClientSecret---",
    ProjectId = "47C230B4-0000-0000-0000-000000001234",
    Environment = "dev",
    Recursive = true
};

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddInfisical(options, false, TimeSpan.FromMinutes(10));

```

### Using Paths

```csharp
using OLT.Extensions.Configuration.Infisical;

var sharedOptions = new InfisicalOptions
{
    ClientId = "E2BCF5B2-0000-0000-0000-000000009876",
    ClientSecret = "---ClientSecret---",
    ProjectId = "47C230B4-0000-0000-0000-000000001234",
    Environment = "staging",
    Path = "/Shared"
    Recursive = true
};

builder.AddInfisical(sharedOptions, true, TimeSpan.FromMinutes(10));

var appOptions = new InfisicalOptions
{
    ClientId = "E2BCF5B2-0000-0000-0000-000000009876",
    ClientSecret = "---ClientSecret---",
    ProjectId = "47C230B4-0000-0000-0000-000000001234",
    Environment = "staging",
    Path = "/App1"
};

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddInfisical(appOptions, false, TimeSpan.FromMinutes(10));

```
