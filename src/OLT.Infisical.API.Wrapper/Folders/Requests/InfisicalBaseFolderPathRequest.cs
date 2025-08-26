using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders.Requests;

public abstract class InfisicalBaseFolderPathRequest : InfisicalBaseFolderRequest
{
    /// <summary>
    /// default: /
    /// </summary>
    [JsonPropertyName("path")]
    public required string Path { get; init; } = LibConstants.RootPath;
}