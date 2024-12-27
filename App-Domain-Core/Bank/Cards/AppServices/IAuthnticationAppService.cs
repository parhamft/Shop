using App_Domain_Core.Bank.Cards.Services;

namespace App_Domain_Core.Bank.Cards.AppServices
{
    public interface IAuthnticationAppService
    {
        public Card Login(string cardnum, string password);
    }
}
