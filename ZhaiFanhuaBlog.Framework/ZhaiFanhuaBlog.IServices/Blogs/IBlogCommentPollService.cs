// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:IBlogCommentPollService
// Guid:704d0706-ea77-c6ed-17c8-93d7ad94eb77
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2021-12-28 下午 11:10:45
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IServices.Bases;
using ZhaiFanhuaBlog.Models.Blogs;

namespace ZhaiFanhuaBlog.IServices.Blogs;

public interface IBlogCommentPollService : IBaseService<BlogCommentPoll>
{
    Task<BlogCommentPoll> IsExistenceAsync(Guid guid);

    Task<bool> InitBlogCommentPollAsync(List<BlogCommentPoll> blogCommentPolls);

    Task<bool> CreateBlogCommentPollAsync(BlogCommentPoll blogCommentPoll);

    Task<bool> DeleteBlogCommentPollAsync(Guid guid, Guid deleteId);

    Task<BlogCommentPoll> ModifyBlogCommentPollAsync(BlogCommentPoll blogCommentPoll);

    Task<BlogCommentPoll> FindBlogCommentPollAsync(Guid guid);

    Task<List<BlogCommentPoll>> QueryBlogCommentPollAsync();
}