using OLT.Infisical.API.Wrapper.Secrets.Query;
using OLT.Infisical.API.Wrapper.Secrets.Request;
using OLT.Infisical.API.Wrapper.Secrets.Response;
using Refit;

namespace OLT.Infisical.API.Wrapper;

public interface IInfisicalApiSecrets
{
    /// <summary>
    /// Create secret
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/create">Documentation</a>
    /// </remarks>
    [Post("/api/v3/secrets/raw/{secretName}")]
    Task<InfiscalSingleSecretResponse> CreateSecret(string secretName, [Body] InfisicalCreateSecretRequest request, CancellationToken ct = default);


    /// <summary>
    /// Update secret
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/update">Documentation</a>
    /// </remarks>
    [Patch("/api/v3/secrets/raw/{secretName}")]
    Task<InfiscalSingleSecretResponse> UpdateSecret(string secretName, [Body] InfisicalUpdateSecretRequest request, CancellationToken ct = default);


    /// <summary>
    /// Delete secret
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/delete">Documentation</a>
    /// </remarks>
    [Delete("/api/v3/secrets/raw/{secretName}")]
    Task<InfiscalSingleSecretResponse> DeleteSecret(string secretName, [Body] InfisicalDeleteSecretRequest request, CancellationToken ct = default);


    /// <summary>
    /// Get a secret by <paramref name="secretName"/>
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/read">Documentation</a>
    /// </remarks>
    [Get("/api/v3/secrets/raw/{secretName}")]
    Task<InfiscalSingleSecretResponse> RetrieveSecret(string secretName, [Query] InfisicalGetSecretQuery query, CancellationToken ct = default);


    /// <summary>
    /// List secrets
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/list">Documentation</a>
    /// </remarks>
    [Get("/api/v3/secrets/raw")]
    Task<InfiscalMultiSecretResponse> ListSecrets([Query] InfisicalListSecretsQuery query, CancellationToken ct = default);

    /// <summary>
    /// Update many secrets
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/update-many">Documentation</a>
    /// </remarks>
    [Patch("/api/v3/secrets/batch/raw")]
    Task<InfiscalMultiSecretResponse> BulkUpdate([Body] InfisicalBulkUpdateRequest request, CancellationToken ct = default);


    /// <summary>
    /// Create many secrets
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/create-many">Documentation</a>
    /// </remarks>
    [Post("/api/v3/secrets/batch/raw")]
    Task<InfiscalMultiSecretResponse> BulkCreate([Body] InfisicalBulkCreateRequest request, CancellationToken ct = default);

    /// <summary>
    /// Delete many secrets
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/delete-many">Documentation</a>
    /// </remarks>
    [Delete("/api/v3/secrets/batch/raw")]
    Task<InfiscalMultiSecretResponse> BulkDelete([Body] InfisicalBulkDeleteRequest request, CancellationToken ct = default);

    /// <summary>
    /// Attach tags to a secret
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/attach-tags">Documentation</a>
    /// </remarks>
    [Post("/api/v3/secrets/tags/{secretName}")]
    Task<InfiscalSingleSecretResponse> AttachTags(string secretName, [Body] InfisicalAttachTagsRequest request, CancellationToken ct = default);

    /// <summary>
    /// Detach tags to a secret
    /// </summary>
    /// <remarks>
    /// <a href="https://infisical.com/docs/api-reference/endpoints/secrets/detach-tags">Documentation</a>
    /// </remarks>
    [Delete("/api/v3/secrets/tags/{secretName}")]
    Task<InfiscalSingleSecretResponse> DetachTags(string secretName, [Body] InfisicalDetachTagsRequest request, CancellationToken ct = default);




}

