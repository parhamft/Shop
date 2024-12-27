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

        ITransactionReposetory trepo = new TransactionReposetory();
        ICardReposetory crepo = new CardReposetory();
        ITransferService tservice= new TransferService();
        public string transfer(Card cs, string DestinationCardNumber, float Amount)
        {
            tservice.CheckLimit(cs,Amount);
            float Fee =  tservice.GetFee(Amount);
            Card dc = tservice.ValidateCard(DestinationCardNumber);
            tservice.CheckBalance(cs,Fee,Amount);
            tservice.TempPassword();




            if (crepo.Deposit(dc.CardNumber, Amount) == false) { return "something went Wrong"; }
            if (crepo.Withdraw(cs.CardNumber, (Amount * (1 + Fee / 100))) == false) { return "something went Wrong"; }
            Transaction t = new Transaction(cs.CardNumber, DestinationCardNumber, Amount, DateTime.Now, true);
            if (trepo.create(t) == false) { return "something went Wrong"; }
            return "transaction compeleted";
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
        public string RecieversInfo(string cardnum)
        {
            return tservice.RecieversInfo(cardnum);
        }

    }
}
