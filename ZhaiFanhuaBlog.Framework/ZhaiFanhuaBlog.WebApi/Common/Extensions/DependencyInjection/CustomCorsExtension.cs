// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:CustomCorsExtension
// Guid:031b8d2e-2f06-4b1c-af6d-7a4a0fde77ef
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-03 下午 03:13:42
// ----------------------------------------------------------------

namespace ZhaiFanhuaBlog.WebApi.Common.Extensions.DependencyInjection;

/// <summary>
/// CustomCorsExtension
/// </summary>
public static class CustomCorsExtension
{
    /// <summary>
    /// Cors服务扩展
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration config)
    {
        services.AddCors(options =>
        {
            // 策略名称
            string policyName = config.GetSection("Cors:PolicyName").Get<string>();
            // 添加指定策略
            options.AddPolicy(name: policyName, policy =>
            {
                // 支持多个域名端口，端口号后不可带/符号
                string[] origins = config.GetSection("Cors:Origins").Get<string[]>();
                // 配置允许访问的域名
                policy.WithOrigins(origins)
                // 是否允许源时匹配配置的通配符域
                .SetIsOriginAllowedToAllowWildcardSubdomains()
                // 允许任何方法
                .AllowAnyMethod()
                // 允许任何请求头
                .AllowAnyHeader()
                // 允许凭据
                .AllowCredentials();
            });
        });
        return services;
    }

    /// <summary>
    /// Cors应用扩展
    /// </summary>
    /// <param name="app"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app, IConfiguration config)
    {
        // 策略名称
        string policyName = config.GetSection("Cors:PolicyName").Get<string>();
        // 对 UseCors 的调用必须放在 UseRouting 之后，但在 UseAuthorization 之前
        app.UseCors(policyName);
        return app;
    }
}