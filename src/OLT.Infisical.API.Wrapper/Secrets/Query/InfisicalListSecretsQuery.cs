using Refit;

namespace OLT.Infisical.API.Wrapper.Secrets.Query;

//NOTE: This class can not be inherited 
public class InfisicalListSecretsQuery
{
    [AliasAs("workspaceId")]
    public required virtual string WorkspaceId { get; init; }

    [AliasAs("environment")]
    public required string Environment { get; init; }

    [AliasAs("secretPath")]
    public required string SecretPath { get; init; } = LibConstants.RootPath;

    /// <summary>
    /// The secret metadata key-value pairs to filter secrets by. When querying for multiple metadata pairs, the query is treated as an AND operation. 
    /// </summary>
    /// <remarks>
    /// Secret metadata format is: key=value1,value=value2|key=value3,value=value4.
    /// </remarks>
    [AliasAs("metadataFilter")]
    public string? MetadataFilter { get; init; }

    [AliasAs("recursive")]
    public bool Recursive { get; init; } = false;

    /// <summary>
    /// Comma-separated list of tag slugs to filter by
    /// </summary>
    [AliasAs("tagSlugs")]
    public string? TagSlugs { get; init; }

    [AliasAs("version")]
    public int? Version { get; init; }

    [AliasAs("viewSecretValue")]
    public bool ViewSecretValue { get; init; } = true;

    [AliasAs("expandSecretReferences")]
    public bool ExpandSecretReferences { get; init; } = false;

    [AliasAs("includeImports")]
    public bool IncludeImports { get; init; } = false;

}
