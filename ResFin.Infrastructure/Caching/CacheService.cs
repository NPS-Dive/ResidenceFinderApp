using System.Buffers;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using ResFin.Application.Abstractions.Caching;

namespace ResFin.Infrastructure.Caching;

internal sealed class CacheService : ICacheService
    {
    private readonly IDistributedCache _cache;

    public CacheService ( IDistributedCache cache )
        {
        _cache = cache;
        }

    public async Task<T?> GetAsync<T> ( string key, CancellationToken cancellationToken = default )
        {
        byte[]? bytesArray = await _cache.GetAsync(key, cancellationToken);

        return bytesArray is null
            ? default
            : Deserialized<T>(bytesArray);
        }



    public Task SetAsync<T> ( string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default )
        {
        byte[] bytesArray = Serialize(value);
        return _cache.SetAsync(key, bytesArray, CacheOptions.Create(expiration), cancellationToken);
        }



    public Task RemoveAsync ( string key, CancellationToken cancellationToken )
        {
        return _cache.RemoveAsync(key, cancellationToken);
        }

    private static T Deserialized<T> ( byte[] bytesArray )
        {
        return JsonSerializer.Deserialize<T>(bytesArray);
        }

    private static byte[] Serialize<T> ( T value )
        {
        var buffer = new ArrayBufferWriter<byte>();
        using var writer = new Utf8JsonWriter(buffer);
        JsonSerializer.Serialize(writer, value);
        var resultArray = buffer.WrittenSpan.ToArray();

        return resultArray;
        }
    }