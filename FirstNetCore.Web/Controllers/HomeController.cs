using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstNetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AuthorizeFilter(Roles = AuthorizationHelper.LoginRole)]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = AuthorizationHelper.LoginRole)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [Authorize(Roles = AuthorizationHelper.LoginRole)]
        public ContentResult Test()
        {
            return Content("王亮test001");
        }

        public IActionResult AuthPage()
        {
            return View();
        }
    }
}
