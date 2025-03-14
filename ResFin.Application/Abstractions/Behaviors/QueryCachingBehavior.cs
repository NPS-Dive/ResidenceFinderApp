using ResFin.Application.Abstractions.Caching;

namespace ResFin.Application.Abstractions.Behaviors;

internal sealed class QueryCachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
where TRequest : ICachedQuery
where TResponse : Result
    {
    private readonly ICacheService _cacheService;
    private readonly ILogger<QueryCachingBehavior<TRequest, TResponse>> _logger;

    #region Cunstructor

    public QueryCachingBehavior (
        ICacheService cacheService,
        ILogger<QueryCachingBehavior<TRequest, TResponse>> logger
    )
        {
        _cacheService = cacheService;
        _logger = logger;
        }

    #endregion

    public async Task<TResponse> Handle (
    TRequest request,
    RequestHandlerDelegate<TResponse> next,
    CancellationToken cancellationToken
    )
        {
        TResponse? cahcedResult = await _cacheService
            .GetAsync<TResponse>(request.CacheKey, cancellationToken);

        string name = typeof(TRequest).Name;

        if (cahcedResult is not null)
            {
            _logger.LogInformation("Cache hit for {Query}", name);
            return cahcedResult;
            }

        _logger.LogInformation("Cache miss for {Query}", name);
        var result = await next();

        if (result.IsSuccess)
            {
            await _cacheService.SetAsync(request.CacheKey, result, request.Expiration, cancellationToken);
            }

        return result;
        }
    }