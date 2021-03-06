// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:UserFollow
// Guid:196d9961-eb5f-4e8d-807d-a29b87a0a4f9
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 06:05:37
// ----------------------------------------------------------------

using SqlSugar;
using ZhaiFanhuaBlog.Models.Bases;

namespace ZhaiFanhuaBlog.Models.Users;

/// <summary>
/// 用户关注表
/// </summary>
[SugarTable("UserFollow", "用户关注表")]
public class UserFollow : BaseEntity
{
    /// <summary>
    /// 所属用户
    /// </summary>
    [SugarColumn(ColumnDescription = "所属用户")]
    public Guid AccountId { get; set; }

    /// <summary>
    /// 关注用户
    /// </summary>
    [SugarColumn(ColumnDescription = "关注用户")]
    public Guid FollowedAccountId { get; set; }

    /// <summary>
    /// 备注名称
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(20)", IsNullable = true, ColumnDescription = "备注名称")]
    public string? RemarkName { get; set; }
}