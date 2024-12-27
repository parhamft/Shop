using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.Cards.Services;
using quiz.Services;

namespace App_Domain_AppService.Bank
{
    public class AuthnticationAppService : IAuthnticationAppService
    {
        Iauthentication auth = new authentication();
        public Card Login(string cardnum, string password)

        {
            return auth.Login(cardnum, password);
        }
    }
}

