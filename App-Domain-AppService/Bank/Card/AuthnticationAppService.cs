using App_Domain_Core.Bank.Cards.AppServices;
using App_Domain_Core.Bank.Cards.Services;
using quiz.Services;

namespace App_Domain_AppService.Bank
{
    public class AuthnticationAppService : IAuthnticationAppService
    {
        private readonly Iauthentication auth;
        public AuthnticationAppService(Iauthentication iauthentication)
        {
            auth = iauthentication;
        }
        public Card Login(string cardnum, string password)

        {
            return auth.Login(cardnum, password);
        }
    }
}

