// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:RUserAccountRoleDto
// Guid:8a96fb06-2712-4560-9c8d-e4493e97e557
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-07-03 下午 07:10:03
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.ViewModels.Bases;

namespace ZhaiFanhuaBlog.ViewModels.Users;

/// <summary>
/// RUserAccountRoleDto
/// </summary>
public class RUserAccountRoleDto : RBaseDto
{
    /// <summary>
    /// 用户账户
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// 用户角色
    /// </summary>
    public Guid RoleId { get; set; }

    public virtual IEnumerable<RUserAccountDto>? UserAccounts { get; set; }

    public virtual IEnumerable<RUserRoleDto>? UserRoles { get; set; }
}