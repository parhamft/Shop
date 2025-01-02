using App_Domain_Core.Bank.Cards.Services;
using App_Domain_Core.Bank.contract;
using quiz.Contracts;
using quiz.Entities;
using quiz.reposetories;

namespace quiz.Services
{
    public class TransferService  :ITransferService
    {
        private readonly ITransactionReposetory trepo;
        private readonly ICardReposetory crepo;

        public TransferService(ITransactionReposetory transactionReposetory, ICardReposetory cardReposetory)
        {
            trepo = transactionReposetory;
            crepo = cardReposetory;
        }

        public bool CheckLimit(Card cs, float Amount)
        {
            float total = 0;
            foreach (Transaction trans in trepo.GetAllReports(cs.CardNumber))
            {
                if (DateOnly.FromDateTime(trans.TransferDate) == DateOnly.FromDateTime(DateTime.Now))
                {
                    if (trans.SourceCardNumber == cs.CardNumber) { total += trans.Amount; }
                }
            }
            total += Amount;
            if (total > 2500) { throw new Exception("you can no longer transfer any money for today"); }
            return true;
        }
        public float GetFee(float Amount)
        {
            if (Amount >= 1000) { return 1.5f; }
            else { return  0.5f; }
        }
        public Card ValidateCard(string DestinationCardNumber)
        {
            Card dc = crepo.GetById(DestinationCardNumber);
            if (dc == null) { throw new Exception("Destination Card does not exist"); }
            return dc ;
        }
        public bool CheckBalance(Card cs, float Fee, float Amount)
        {
            if (cs.Balance < Amount * (1 + Fee / 100)) { throw new Exception ("not enough balance"); }
            return true ;
        }
        public string TempPassword()
        {
            Random random = new Random();
            int code = random.Next(100000, 999999);
            TempCode temp = new TempCode();
            temp.password = code;
            PasswordStorage.InsertCode(temp);
            return Convert.ToString(code);
        }
        public string Transfer( Card cs, Card dc,float Amount, String DestinationCardNumber, float Fee)
        {
            if (crepo.Deposit(dc.CardNumber, Amount) == false) { return "something went Wrong"; }
            if (crepo.Withdraw(cs.CardNumber, (Amount * (1 + Fee / 100))) == false) { return "something went Wrong"; }
            Transaction t = new Transaction(cs.CardNumber, DestinationCardNumber, Amount, DateTime.Now, true);
            if (trepo.create(t) == false) { return "something went Wrong"; }
            return "transaction compeleted";
        }

        public List<Transaction> Reports(string cardnum)
        {
            if (crepo.GetById(cardnum) == null) { throw new Exception("that card does not exist"); }
            return trepo.GetAllReports(cardnum);

        }
        public string ChangePassword(string cardnum,string OldPassword, string password)
        {
            var card= crepo.GetById(cardnum);
            if (card.Password != OldPassword)
            {
                throw new Exception("the old password is incorrect");
            }
            crepo.ChangePassword(cardnum, password);
            return "password Changed";
        }
        public float CheckBalance(string cardnum)
        {
            return crepo.GetById(cardnum).Balance;
        }
        public Card RecieversInfo(string cardnum)
        {
            var card = crepo.GetById(cardnum);
            if (card == null) { throw new Exception("this card does not exist"); }
            return card;
        }

    }
}
