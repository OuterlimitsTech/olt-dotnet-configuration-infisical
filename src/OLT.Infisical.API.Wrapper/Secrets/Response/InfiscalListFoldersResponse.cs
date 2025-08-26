using OLT.Infisical.API.Wrapper.Folders;

namespace OLT.Infisical.API.Wrapper.Secrets.Response;

public sealed class InfiscalListFoldersResponse
{
    public List<InfiscalFolder> Folders { get; init; } = new List<InfiscalFolder>();
}