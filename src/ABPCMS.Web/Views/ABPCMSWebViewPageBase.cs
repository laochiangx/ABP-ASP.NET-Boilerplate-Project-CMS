using Abp.Web.Mvc.Views;

namespace ABPCMS.Web.Views
{
    public abstract class ABPCMSWebViewPageBase : ABPCMSWebViewPageBase<dynamic>
    {

    }

    public abstract class ABPCMSWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ABPCMSWebViewPageBase()
        {
            LocalizationSourceName = ABPCMSConsts.LocalizationSourceName;
        }
    }
}