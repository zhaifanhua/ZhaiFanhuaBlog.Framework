// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:IUserRoleService
// Guid:619a9c65-08b5-b2c7-0e17-57a30f09e61d
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-01-06 下午 10:37:03
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IServices.Bases;
using ZhaiFanhuaBlog.Models.Users;

namespace ZhaiFanhuaBlog.IServices.Users;

public interface IUserRoleService : IBaseService<UserRole>
{
    Task<UserRole> IsExistenceAsync(Guid guid);

    Task<bool> InitUserRoleAsync(List<UserRole> userRoles);

    Task<bool> CreateUserRoleAsync(UserRole userRole);

    Task<bool> DeleteUserRoleAsync(Guid guid, Guid deleteId);

    Task<UserRole> ModifyUserRoleAsync(UserRole userRole);

    Task<UserRole> FindUserRoleAsync(Guid guid);

    Task<List<UserRole>> QueryUserRoleAsync();
}