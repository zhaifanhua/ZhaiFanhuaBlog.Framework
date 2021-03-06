// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:CustomRouteExtension
// Guid:110bb71a-7214-4344-8aea-ce3de16c4cae
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-30 上午 03:15:11
// ----------------------------------------------------------------

namespace ZhaiFanhuaBlog.WebApi.Common.Extensions.DependencyInjection;

/// <summary>
/// CustomRouteExtension
/// </summary>
public static class CustomRouteExtension
{
    /// <summary>
    /// Route服务扩展
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomRoute(this IServiceCollection services, IConfiguration config)
    {
        services.AddRouting(route =>
        {
            route.LowercaseUrls = true;
            route.LowercaseQueryStrings = true;
        });
        return services;
    }
}