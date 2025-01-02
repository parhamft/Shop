using App.Infra.Data.Repos.Ef;
using App_Domain_AppService.Bank;
using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.contract;
using Microsoft.AspNetCore.Mvc;
using quiz.Entities;

namespace MVC_Shop.Controllers
{
    public class ReportController : Controller
    {

        private readonly  ITransferAppService Service;
        public ReportController(ITransferAppService transferAppService)
        {
            Service = transferAppService;
        }

        public IActionResult Index()
        {
            if (Auth.CurrentUser ==null)
                {
                return Redirect("/Authentication/Login");
            }
            List<Transaction> tranlist = Service.Reports(Auth.CurrentUser.CardNumber);
            return View(tranlist);
        }
    }
}
