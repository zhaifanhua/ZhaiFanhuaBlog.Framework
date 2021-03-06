// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:BaseStateEntity
// Guid:d7e76ed6-1892-45f7-9cef-6541f17d339f
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 04:08:47
// ----------------------------------------------------------------

using SqlSugar;
using ZhaiFanhuaBlog.Models.Roots;

namespace ZhaiFanhuaBlog.Models.Bases;

/// <summary>
/// 状态基类，含主键，创建，修改，删除
/// </summary>
public abstract class BaseStateEntity<Tkey> : BaseAuditEntity<Guid>
{
    /// <summary>
    /// 状态主键
    /// </summary>
    [SugarColumn(IsIgnore = true, ColumnDescription = "状态主键")]
    public virtual Guid? StateId { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public RootState? RootState { get; set; }
}