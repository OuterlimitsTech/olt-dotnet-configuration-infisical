using OLT.Infisical.API.Wrapper.Folders.Query;
using OLT.Infisical.API.Wrapper.Folders.Requests;
using OLT.Infisical.API.Wrapper.Folders.Response;
using Refit;

namespace OLT.Infisical.API.Wrapper;

public interface IInfisicalApiFolders
{
    /// <summary>
    /// Create folder
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/folders/create">Documentation</a>
    /// </remarks>
    [Post("/api/v1/folders")]
    Task<InfisicalSingleFolderResponse> CreateFolder([Body] InfiscalCreateFolderRequest request, CancellationToken ct = default);

    /// <summary>
    /// Update folder
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/folders/update">Documentation</a>
    /// </remarks>
    [Patch("/api/v1/folders/{folderName}")]
    Task<InfisicalSingleFolderResponse> UpdateFolder(string folderName, [Body] InfisicalUpdateFolderRequest request, CancellationToken ct = default);

    /// <summary>
    /// Delete folder
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/folders/delete">Documentation</a>
    /// </remarks>
    [Delete("/api/v1/folders/{folderName}")]
    Task<InfisicalSingleFolderResponse> DeleteFolder(string folderName, [Body] InfisicalDeleteFolderRequest request, CancellationToken ct = default);

    /// <summary>
    /// Get folder by <paramref name="id"/>
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/folders/get-by-id">Documentation</a>
    /// </remarks>
    [Get("/api/v1/folders/{id}")]
    Task<InfisicalSingleFolderResponse> GetFolder(string id, CancellationToken ct = default);

    /// <summary>
    /// Get folders
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/folders/list">Documentation</a>
    /// </remarks>
    [Get("/api/v1/folders")]
    Task<InfisicalMultiFolderResponse> ListFolders([Query] InfisicalListFoldersQuery query, CancellationToken ct = default);
}

