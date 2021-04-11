using Microsoft.Extensions.Caching.Memory;
using System;
using tradeofexile.application.Interfaces;

public class CacheProvider : ICacheProvider
{
    private readonly IMemoryCache _cache;
    public CacheProvider(IMemoryCache cache)
    {
        _cache = cache;
    }

    private const int LiveTimeMinutes = 10;

    public void ClearCache(string key)
    {
        _cache.Remove(key);
    }
    public T GetFromCache<T>(string key) where T : class
    {
        _cache.TryGetValue(key, out T result);
        return result;
    }

    public void SetCache<T>(string key, T value) where T : class
    {
        SetCache<T>(key, value, DateTimeOffset.Now.AddMinutes(LiveTimeMinutes));
    }

    public void SetCache<T>(string key, T value, DateTimeOffset duration) where T : class
    {
        _cache.Set(key, value, duration);
    }

    public void SetCache<T>(string key, T value, MemoryCacheEntryOptions options) where T : class
    {
        _cache.Set(key, value, options);
    }
}