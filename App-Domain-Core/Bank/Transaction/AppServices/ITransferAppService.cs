using App_Domain_Core.Bank.Cards.Services;
using quiz.Entities;

namespace App_Domain_Core.Bank.contract
{
    public interface ITransferAppService
    {
        public string transfer(Card cs, string DestinationCardNumber, float Amount);
        public List<Transaction> Reports(string cardnum);

        public string ChangePassword(string cardnum, string OldPassword, string password);
        public float CheckBalance(string cardnum);
        public Card RecieversInfo(string cardnum);
        public string TempCode();
    }
}
