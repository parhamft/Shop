using App.Infra.Data.Repos.Ef;
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
        private readonly IAuthnticationAppService auth;
        public AuthenticationController(IAuthnticationAppService authnticationAppService)
        {
            auth = authnticationAppService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string username, string password)
        {

            if (auth.Login(username, password) == null)
            {
                TempData["Message"] = "Something is Wrong";
                TempData["AlertType"] = "danger";
                return View();
            }
            Auth.CurrentUser= auth.Login(username, password);
            TempData["Message"] = "Logged in succesfully";
            TempData["AlertType"] = "success";
            return View();
        }
    }
}
