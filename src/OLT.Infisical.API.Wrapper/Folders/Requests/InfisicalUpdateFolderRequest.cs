namespace OLT.Infisical.API.Wrapper.Folders.Requests;

public sealed class InfisicalUpdateFolderRequest : InfisicalBaseFolderPathRequest
{
    public required string NewFolderName { get; init; }
}
