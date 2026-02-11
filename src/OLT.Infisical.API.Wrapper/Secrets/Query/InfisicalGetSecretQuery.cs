using Refit;

namespace OLT.Infisical.API.Wrapper.Secrets.Query;

//NOTE: This class can not be inherited 
public sealed class InfisicalGetSecretQuery 
{
    [AliasAs("workspaceId")]
    public required string WorkspaceId { get; init; }

    [AliasAs("environment")]
    public required string Environment { get; init; }

    [AliasAs("secretPath")]
    public required string SecretPath { get; init; } = LibConstants.RootPath;

    [AliasAs("type")]
    public string? Type { get; init; } 

    [AliasAs("version")]
    public int? Version { get; init; }

    [AliasAs("viewSecretValue")]
    public bool ViewSecretValue { get; init; } = true;

    [AliasAs("expandSecretReferences")]
    public bool ExpandSecretReferences { get; init; } = false;

    [AliasAs("includeImports")]
    public bool IncludeImports { get; init; } = false;
}
