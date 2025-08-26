using OLT.Infisical.API.Wrapper.Secrets.Request;
using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Secrets.Query;

public sealed class InfisicalListSecretsQuery : InfisicalBaseSecretTypeRequest
{

    /// <summary>
    /// The secret metadata key-value pairs to filter secrets by. When querying for multiple metadata pairs, the query is treated as an AND operation. 
    /// </summary>
    /// <remarks>
    /// Secret metadata format is: key=value1,value=value2|key=value3,value=value4.
    /// </remarks>
    [JsonPropertyName("metadataFilter")]
    public string? MetadataFilter { get; init; }    
    

    [JsonPropertyName("recursive")]
    public bool Recursive { get; init; } = false;

    /// <summary>
    /// Comma-separated list of tag slugs to filter by
    /// </summary>
    [JsonPropertyName("tagSlugs")]
    public string? TagSlugs { get; init; }

    [JsonPropertyName("version")]
    public int? Version { get; init; }

    [JsonPropertyName("viewSecretValue")]
    public bool ViewSecretValue { get; init; } = true;

    [JsonPropertyName("expandSecretReferences")]
    public bool ExpandSecretReferences { get; init; } = false;

    [JsonPropertyName("includeImports")]
    public bool IncludeImports { get; init; } = false;

}
