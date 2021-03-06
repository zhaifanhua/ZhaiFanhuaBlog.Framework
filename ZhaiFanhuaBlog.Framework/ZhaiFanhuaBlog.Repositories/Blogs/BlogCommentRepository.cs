// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:BlogCommentRepository
// Guid:96806f3d-d1df-4e81-9c02-1bcea4b5d3ae
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-05-08 下午 09:44:40
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IRepositories.Blogs;
using ZhaiFanhuaBlog.Models.Blogs;
using ZhaiFanhuaBlog.Repositories.Bases;

namespace ZhaiFanhuaBlog.Repositories.Blogs;

/// <summary>
/// BlogCommentRepository
/// </summary>
public class BlogCommentRepository : BaseRepository<BlogComment>, IBlogCommentRepository
{
}