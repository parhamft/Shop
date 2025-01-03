using App.Infra.Data.Repos.Ef;
using App_Domain_AppService.Bank;
using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.contract;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Shop.Controllers
{
    public class TransactionController : Controller
    {

        private readonly ITransferAppService Service;

        public TransactionController(ITransferAppService transferAppService)
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

        [HttpPost]
        public IActionResult NextStep(string Number, float Amount)
        {
            Auth.number= Number;
            Auth.amount= Amount;
            Auth.tempcode = Service.TempCode();
          
            return RedirectToAction("Final");
        }

        public IActionResult Final()
        {
            var name = Service.RecieversInfo(Auth.number);
            return View(name);
        }
        [HttpPost]
        public IActionResult transfer(string code)
        {
            if (code != Auth.tempcode)
            {
                TempData["Message"] = "Something is Wrong";
                TempData["AlertType"] = "danger";
                return RedirectToAction("Final");
            }
            Service.transfer(Auth.CurrentUser,Auth.number,Auth.amount);
            return Redirect("/Report");
        }
    }
}
