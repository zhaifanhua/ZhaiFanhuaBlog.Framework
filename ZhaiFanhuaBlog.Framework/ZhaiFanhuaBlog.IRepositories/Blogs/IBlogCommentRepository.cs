// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:IBlogCommentRepository
// Guid:4295a760-af83-4946-af92-b878f3e07078
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 09:10:54
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IRepositories.Bases;
using ZhaiFanhuaBlog.Models.Blogs;

namespace ZhaiFanhuaBlog.IRepositories.Blogs;

/// <summary>
/// IBlogCommentRepository
/// </summary>
public interface IBlogCommentRepository : IBaseRepository<BlogComment>
{
}