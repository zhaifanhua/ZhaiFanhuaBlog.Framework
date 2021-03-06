// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:UserLogin
// Guid:30e63ed1-9f89-4676-8aa6-9521f6ab3d6d
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 06:11:05
// ----------------------------------------------------------------

using SqlSugar;
using System.Net;
using ZhaiFanhuaBlog.Models.Bases;
using ZhaiFanhuaBlog.Utils.Formats;

namespace ZhaiFanhuaBlog.Models.Users;

/// <summary>
/// 用户登录表
/// </summary>
[SugarTable("UserLogin", "用户登录表")]
public class UserLogin : BaseEntity
{
    /// <summary>
    /// 所属用户
    /// </summary>
    [SugarColumn(ColumnDescription = "所属用户")]
    public Guid AccountId { get; set; }

    /// <summary>
    /// 登录Ip地址
    /// </summary>
    [SugarColumn(ColumnDataType = "varbinary(16)", ColumnDescription = "登录Ip地址")]
    public virtual byte[]? LoginIp
    {
        get => IpFormatHelper.FormatIPAddressToByte(_LoginIp);
        set => _LoginIp = IpFormatHelper.FormatByteToIPAddress(value);
    }

    private IPAddress? _LoginIp;

    /// <summary>
    /// 代理信息
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(100)", IsNullable = true, ColumnDescription = "代理信息")]
    public string? Agent { get; set; }
}