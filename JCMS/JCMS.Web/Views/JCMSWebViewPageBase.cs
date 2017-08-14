using Abp.Web.Mvc.Views;

namespace JCMS.Web.Views
{
    public abstract class JCMSWebViewPageBase : JCMSWebViewPageBase<dynamic>
    {

    }

    public abstract class JCMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected JCMSWebViewPageBase()
        {
            LocalizationSourceName = JCMSConsts.LocalizationSourceName;
        }
    }
}