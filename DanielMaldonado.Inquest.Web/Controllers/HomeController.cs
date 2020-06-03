using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace DanielMaldonado.Inquest.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : InquestControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}