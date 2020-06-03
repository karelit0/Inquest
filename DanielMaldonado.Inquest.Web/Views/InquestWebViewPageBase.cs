using Abp.Web.Mvc.Views;

namespace DanielMaldonado.Inquest.Web.Views
{
    public abstract class InquestWebViewPageBase : InquestWebViewPageBase<dynamic>
    {

    }

    public abstract class InquestWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected InquestWebViewPageBase()
        {
            LocalizationSourceName = InquestConsts.LocalizationSourceName;
        }
    }
}