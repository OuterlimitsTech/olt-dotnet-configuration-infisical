using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders.Requests;

/// <summary>
/// For Requests all requests
/// </summary>
public abstract class InfisicalBaseFolderRequest
{
    [JsonPropertyName("workspaceId")]
    public required string WorkspaceId { get; init; }

    /// <summary>
    /// examples: dev, prod, staging
    /// </summary>
    [JsonPropertyName("environment")]
    public required string Environment { get; init; }

}
