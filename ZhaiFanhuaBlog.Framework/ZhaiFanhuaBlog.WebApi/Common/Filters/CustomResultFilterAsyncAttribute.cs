// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:CustomResultFilterAsyncAttribute
// Guid:0c941b38-e677-4251-a014-2e96fa572311
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-18 上午 01:48:20
// ----------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ZhaiFanhuaBlog.Models.Bases.Response.Model;
using ZhaiFanhuaBlog.Models.Response;

namespace ZhaiFanhuaBlog.WebApi.Common.Filters;

/// <summary>
/// 异步结果过滤器属性(一般用于返回统一模型数据)
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class CustomResultFilterAsyncAttribute : Attribute, IAsyncResultFilter
{
    private readonly ILogger<CustomResultFilterAsyncAttribute> _ILogger;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger"></param>
    public CustomResultFilterAsyncAttribute(ILogger<CustomResultFilterAsyncAttribute> logger)
    {
        _ILogger = logger;
    }

    /// <summary>
    /// 在某结果执行时
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        Console.WriteLine("CustomResultFilterAsyncAttribute.OnResultExecutionAsync Before");
        // 获取控制器信息
        ControllerActionDescriptor? actionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
        // 获取路由表信息
        var routeData = context.RouteData;
        var controllerName = routeData.Values["controller"];
        var actionName = routeData.Values["action"];
        var areaName = routeData.DataTokens["area"];
        // 不为空就做处理
        if (context.Result != null)
        {
            if (context.Result is ResultModel resultModel)
            {
                // 如果是通用数据类返回结果，则转换为json结果
                context.Result = new JsonResult(resultModel);
            }
            else if (context.Result is ObjectResult objectResult)
            {
                // 如果是对象结果，则转换为json结果
                context.Result = new JsonResult(objectResult!.Value!);
            }
            else if (context.Result is ContentResult contentResult)
            {
                // 如果是内容结果，则转换为json结果
                context.Result = new JsonResult(contentResult!.Content!);
            }
            else if (context.Result is JsonResult jsonResult)
            {
                // 如果是json结果，则转换为json结果
                context.Result = new JsonResult(jsonResult.Value);
            }
            else if (context.Result is EmptyResult)
            {
                // 如果是空结果，则转换为json结果
                context.Result = new JsonResult(ResultResponse.OK());
            }
            else
            {
                // 其他结果，则转换为json结果
                throw new Exception($"未经处理的Result类型：{context.Result.GetType().Name}");
            }
        }
        // 请求构造函数和方法,调用下一个过滤器
        ResultExecutedContext resultExecuted = await next();
        // 执行结果
        try
        {
            if (resultExecuted.Result != null)
            {
                var result = JsonConvert.SerializeObject(resultExecuted.Result);
                _ILogger.LogInformation($"执行结果为【{JsonConvert.SerializeObject(result)}】");
            }
        }
        catch (Exception)
        {
            throw;
        }
        Console.WriteLine("CustomResultFilterAsyncAttribute.OnResultExecutionAsync After");
    }
}