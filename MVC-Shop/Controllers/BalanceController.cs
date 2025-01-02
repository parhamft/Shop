using App.Infra.Data.Repos.Ef;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Shop.Controllers
{
    public class BalanceController : Controller
    {
        public IActionResult Index()
        {
            if (Auth.CurrentUser == null)
            {
                return Redirect("/Authentication/Login");
            }
            var cur= Auth.CurrentUser;
            return View(cur);
        }
    }
}
