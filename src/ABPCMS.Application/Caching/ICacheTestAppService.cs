using Abp.Application.Services;
using Abp.Application.Services.Dto;
using ABPCMS.Caching.Dto;

namespace ABPCMS.Caching
{
    public interface ICacheTestAppService : IApplicationService
    {
        ArticleDto GetArticle(IdInput input);
        ArticleDto CreateArticle(ArticleDto input);
    }
}