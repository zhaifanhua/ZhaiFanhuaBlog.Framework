// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:UserFollowService
// Guid:2b5191b8-3905-49ef-b6c6-39b5e56694b9
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-04 下午 06:04:21
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IRepositories.Users;
using ZhaiFanhuaBlog.IServices.Users;
using ZhaiFanhuaBlog.Models.Users;
using ZhaiFanhuaBlog.Services.Bases;

namespace ZhaiFanhuaBlog.Services.Users;

/// <summary>
/// UserFollowService
/// </summary>
public class UserFollowService : BaseService<UserFollow>, IUserFollowService
{
    private readonly IUserFollowRepository _IUserFollowRepository;

    public UserFollowService(IUserFollowRepository iUserFollowRepository)
    {
        _IUserFollowRepository = iUserFollowRepository;
        base._IBaseRepository = iUserFollowRepository;
    }
}