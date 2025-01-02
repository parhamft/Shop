using App_Domain_Core.Bank.Cards.Services;
using App_Domain_Core.Bank.contract;
using quiz.Contracts;
using quiz.Entities;
using quiz.reposetories;
using quiz.Services;

namespace App_Domain_AppService.Bank
{
    public class TransferAppService : ITransferAppService
    {

        private readonly ITransferService tservice;
        public TransferAppService(ITransferService transferService)
        {
            tservice = transferService;
        }
        public string transfer(Card cs, string DestinationCardNumber, float Amount)
        {
            tservice.CheckLimit(cs,Amount);
            float Fee =  tservice.GetFee(Amount);
            Card dc = tservice.ValidateCard(DestinationCardNumber);
            tservice.CheckBalance(cs,Fee,Amount);
            tservice.TempPassword();

            return tservice.Transfer(cs,dc,Amount,DestinationCardNumber,Fee);


 
        }
        public List<Transaction> Reports(string cardnum)
        {
            return tservice.Reports(cardnum);
        }

        public string ChangePassword(string cardnum, string OldPassword, string password)
        {
            return tservice.ChangePassword(cardnum, OldPassword, password);
        }
        public float CheckBalance(string cardnum)
        {
             return tservice.CheckBalance(cardnum);
        }
        public Card RecieversInfo(string cardnum)
        {
            return tservice.RecieversInfo(cardnum);
        }
        public string TempCode()
        {
            return tservice.TempPassword();
        }

    }
}
