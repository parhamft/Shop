using App_Domain_AppService.Bank;
using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.Cards.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using quiz.Services;

namespace MVC_Shop.Controllers
{
    public class AuthenticationController : Controller
    {
        IAuthnticationAppService auth = new AuthnticationAppService();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string username, string password)
        {

            if (auth.Login() == false)
            {
                TempData["Message"] = "Something is Wrong";
                TempData["AlertType"] = "danger";
                return View();
            }

            TempData["Message"] = "Logged in succesfully";
            TempData["AlertType"] = "success";
            return View();
        }
    }
}
