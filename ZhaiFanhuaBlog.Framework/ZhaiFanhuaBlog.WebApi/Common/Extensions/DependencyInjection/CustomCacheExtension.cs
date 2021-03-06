// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:CustomCacheExtension
// Guid:5c45f05d-b77a-4ffa-8975-77aff404eb20
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-28 下午 11:29:28
// ----------------------------------------------------------------

using CSRedis;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;

namespace ZhaiFanhuaBlog.WebApi.Common.Extensions.DependencyInjection;

/// <summary>
/// CustomCacheExtension
/// </summary>
public static class CustomCacheExtension
{
    /// <summary>
    /// Cache服务扩展
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomCache(this IServiceCollection services, IConfiguration config)
    {
        if (config.GetValue<bool>("Cache:IsEnabled"))
        {
            // 内存中缓存
            if (config.GetValue<bool>("Cache:MemoryCache:IsEnabled"))
            {
                services.AddMemoryCache();
            }
            // 分布式缓存
            else if (config.GetValue<bool>("Cache:DistributedCache:IsEnabled"))
            {
                //// ==========分布式内存缓存==========
                //// 分布式内存缓存不是真正的分布式缓存，一般用于在开发和测试场景中，它允许在未来实现真正的分布式缓存解决方案。
                //services.AddDistributedMemoryCache();
                //// ==========分布式 Redis 缓存==========
                //// 1.StackExchangeRedis
                //services.AddStackExchangeRedisCache(options =>
                //{
                //    options.Configuration = config.GetValue<string>("Cache:DistributedCache:Redis:ConnectionString");
                //    options.InstanceName = config.GetValue<string>("Cache:DistributedCache:Redis:InstanceName");
                //});
                //services.AddSingleton<IDistributedCache, RedisCache>();
                // 2.CSRedis
                var connectionString = config.GetValue<string>("Cache:DistributedCache:Redis:ConnectionString");
                var instanceName = config.GetValue<string>("Cache:DistributedCache:Redis:InstanceName");
                var redisStr = $"{connectionString}, prefix = {instanceName}";
                // CSRedis的两种使用方式
                var csredis = new CSRedisClient(redisStr);
                services.AddSingleton(csredis);
                RedisHelper.Initialization(csredis);
                //基于Redis初始化IDistributedCache
                services.AddSingleton<IDistributedCache>(new CSRedisCache(csredis));
            }
            // 响应缓存
            else if (config.GetValue<bool>("Cache:ResponseCache:IsEnabled"))
            {
                services.AddResponseCaching();
            }
        }
        return services;
    }
}