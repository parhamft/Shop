using App_Domain_Core.Bank.Cards.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef
{
    public static class Auth
    {
        public static Card? CurrentUser { get; set; }
        public static string number { get; set; }
        public static float amount { get; set; }
        public static string tempcode { get; set; }

    }
}
