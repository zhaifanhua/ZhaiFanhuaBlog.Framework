// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:UserAuthority
// Guid:8b190341-c474-4974-961f-895c2c6a831d
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 04:45:01
// ----------------------------------------------------------------

using SqlSugar;
using ZhaiFanhuaBlog.Models.Bases;

namespace ZhaiFanhuaBlog.Models.Users;

/// <summary>
/// 用户权限表
/// </summary>
[SugarTable("UserAuthority", "用户权限表")]
public class UserAuthority : BaseEntity
{
    /// <summary>
    /// 父级权限
    /// </summary>
    [SugarColumn(IsNullable = true, ColumnDescription = "父级权限")]
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 权限名称
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(10)", ColumnDescription = "权限名称")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 权限类型
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(10)", ColumnDescription = "权限类型")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// 权限描述
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(50)", IsNullable = true, ColumnDescription = "权限描述")]
    public string? Description { get; set; }
}