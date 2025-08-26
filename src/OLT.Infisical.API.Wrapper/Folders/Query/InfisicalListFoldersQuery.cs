using Refit;

namespace OLT.Infisical.API.Wrapper.Folders.Query;

public sealed class InfisicalListFoldersQuery 
{
    [AliasAs("workspaceId")]
    public required string WorkspaceId { get; init; }

    /// <summary>
    /// examples: dev, prod, staging
    /// </summary>
    [AliasAs("environment")]
    public required string Environment { get; init; }

    /// <summary>
    /// default: /
    /// </summary>
    [AliasAs("path")]
    public required string Path { get; init; } = LibConstants.RootPath;

}
