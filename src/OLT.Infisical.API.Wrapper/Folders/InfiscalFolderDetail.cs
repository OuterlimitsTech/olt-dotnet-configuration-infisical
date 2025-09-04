using System.Text.Json.Serialization;

namespace OLT.Infisical.API.Wrapper.Folders;

public class InfiscalFolder : InfiscalFolderList
{
    //[JsonPropertyName("id")]
    //public string? Id { get; init; }

    //[JsonPropertyName("name")]
    //public string? Name { get; init; }

    //[JsonPropertyName("version")]
    //public int? Version { get; init; }

    //[JsonPropertyName("createdAt")]
    //public DateTime? CreatedAt { get; init; }

    //[JsonPropertyName("updatedAt")]
    //public DateTime? UpdatedAt { get; init; }

    //[JsonPropertyName("envId")]
    //public string? EnvId { get; init; }

    //[JsonPropertyName("parentId")]
    //public string? ParentId { get; init; }

    //[JsonPropertyName("isReserved")]
    //public bool? IsReserved { get; init; }

    //[JsonPropertyName("description")]
    //public string? Description { get; init; }

    //[JsonPropertyName("lastSecretModified")]
    //public DateTime? LastSecretModified { get; init; }

    [JsonPropertyName("environment")]
    public InfiscalFolderDetailEnvironment Environment { get; init; } = new InfiscalFolderDetailEnvironment();

    [JsonPropertyName("path")]
    public string? Path { get; init; }

    [JsonPropertyName("projectId")]
    public string? ProjectId { get; init; }
}

public class InfiscalFolderDetailEnvironment 
{
    [JsonPropertyName("envId")]
    public string? EnvId { get; init; }

    [JsonPropertyName("envName")]
    public string? EnvName { get; init; }

    [JsonPropertyName("envSlug")]
    public string? EnvSlug { get; init; }

}