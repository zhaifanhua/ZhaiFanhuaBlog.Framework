// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:IBlogPollService
// Guid:616bdfe4-38be-9148-ec73-ed849755304d
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2021-12-28 下午 11:25:24
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IServices.Bases;
using ZhaiFanhuaBlog.Models.Blogs;

namespace ZhaiFanhuaBlog.IServices.Blogs;

public interface IBlogPollService : IBaseService<BlogPoll>
{
    Task<BlogPoll> IsExistenceAsync(Guid guid);

    Task<bool> InitBlogPollAsync(List<BlogPoll> blogPolls);

    Task<bool> CreateBlogPollAsync(BlogPoll blogPoll);

    Task<bool> DeleteBlogPollAsync(Guid guid, Guid deleteId);

    Task<BlogPoll> ModifyBlogPollAsync(BlogPoll blogPoll);

    Task<BlogPoll> FindBlogPollAsync(Guid guid);

    Task<List<BlogPoll>> QueryBlogPollAsync();
}