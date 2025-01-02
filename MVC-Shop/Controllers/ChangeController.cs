using App.Infra.Data.Repos.Ef;
using App_Domain_AppService.Bank;
using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.contract;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Shop.Controllers
{
    public class ChangeController : Controller
    {

        private readonly ITransferAppService Service;
        public ChangeController(ITransferAppService transferAppService)
        {
            Service = transferAppService;
        }

        public IActionResult Index()
        {
            if (Auth.CurrentUser == null)
            {
                return Redirect("/Authentication/Login");
            }
            return View();
        }
        public IActionResult ChangePassword(string oldPass,string newPass)
        {
            
            Service.ChangePassword(Auth.CurrentUser.CardNumber, oldPass, newPass);


            return Redirect("/authentication/login");
        }
    }
}
