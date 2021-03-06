// ----------------------------------------------------------------
// Copyright ©2022 ZhaiFanhua All Rights Reserved.
// FileName:BlogArticleService
// Guid:0d15e2e2-c341-4cfc-bd58-1e0d0be8ce10
// Author:zhaifanhua
// Email:me@zhaifanhua.com
// CreateTime:2022-06-04 下午 06:19:12
// ----------------------------------------------------------------

using ZhaiFanhuaBlog.IRepositories.Blogs;
using ZhaiFanhuaBlog.IRepositories.Roots;
using ZhaiFanhuaBlog.IServices.Blogs;
using ZhaiFanhuaBlog.Models.Blogs;
using ZhaiFanhuaBlog.Services.Bases;

namespace ZhaiFanhuaBlog.Services.Blogs;

/// <summary>
/// BlogArticleService
/// </summary>
public class BlogArticleService : BaseService<BlogArticle>, IBlogArticleService
{
    private readonly IRootStateRepository _IRootStateRepository;
    private readonly IBlogArticleRepository _IBlogArticleRepository;

    public BlogArticleService(IRootStateRepository iRootStateRepository, IBlogArticleRepository iBlogArticleRepository)
    {
        base._IBaseRepository = iBlogArticleRepository;
        _IBlogArticleRepository = iBlogArticleRepository;
        _IRootStateRepository = iRootStateRepository;
    }

    /// <summary>
    /// 检验是否存在
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public async Task<BlogArticle> IsExistenceAsync(Guid guid)
    {
        var blogArticle = await _IBlogArticleRepository.FindAsync(e => e.BaseId == guid && !e.SoftDeleteLock);
        if (blogArticle == null)
            throw new ApplicationException("博客文章不存在");
        return blogArticle;
    }

    public async Task<bool> InitBlogArticleAsync(List<BlogArticle> blogArticles)
    {
        blogArticles.ForEach(blogArticle =>
        {
            blogArticle.SoftDeleteLock = false;
        });
        var result = await _IBlogArticleRepository.CreateBatchAsync(blogArticles);
        return result;
    }

    public async Task<bool> CreateBlogArticleAsync(BlogArticle blogArticle)
    {
        if (await _IBlogArticleRepository.FindAsync(e => e.Title == blogArticle.Title && !e.SoftDeleteLock) != null)
            throw new ApplicationException("博客文章标题已存在");
        blogArticle.SoftDeleteLock = false;
        var result = await _IBlogArticleRepository.CreateAsync(blogArticle);
        return result;
    }

    public async Task<bool> DeleteBlogArticleAsync(Guid guid, Guid deleteId)
    {
        var blogArticle = await IsExistenceAsync(guid);
        var rootState = await _IRootStateRepository.FindAsync(e => e.TypeKey == "All" && e.StateKey == -1);
        blogArticle.SoftDeleteLock = true;
        blogArticle.DeleteId = deleteId;
        blogArticle.DeleteTime = DateTime.Now;
        blogArticle.StateId = rootState.BaseId;
        return await _IBlogArticleRepository.UpdateAsync(blogArticle);
    }

    public async Task<BlogArticle> ModifyBlogArticleAsync(BlogArticle blogArticle)
    {
        await IsExistenceAsync(blogArticle.BaseId);
        var result = await _IBlogArticleRepository.UpdateAsync(blogArticle);
        if (result) blogArticle = await _IBlogArticleRepository.FindAsync(blogArticle.BaseId);
        return blogArticle;
    }

    public async Task<BlogArticle> FindBlogArticleAsync(Guid guid)
    {
        var blogArticle = await IsExistenceAsync(guid);
        return blogArticle;
    }

    public async Task<List<BlogArticle>> QueryBlogArticleAsync()
    {
        var blogArticle = from blogarticle in await _IBlogArticleRepository.QueryAsync(e => !e.SoftDeleteLock)
                          orderby blogarticle.CreateTime descending
                          orderby blogarticle.Title descending
                          select blogarticle;
        return blogArticle.ToList();
    }
}