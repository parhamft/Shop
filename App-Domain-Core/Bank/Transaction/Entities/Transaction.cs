using App_Domain_Core.Bank.Cards.Services;

namespace quiz.Entities;

    public class Transaction
    { 
        public int Id { get; set; }
        public string SourceCardNumber { get; set; }
        public Card Card { get; set; }
        public string DestinationCardNumber { get; set; }
        public Card DCard { get; set; }
        public float Amount{ get; set; }
        public DateTime TransferDate{ get; set; }
        public bool isSuccessful { get; set; }

        public Transaction(string SourceCardNumber, string DestinationCardNumber, float Amount,DateTime TransferDate, bool isSuccessful)
        {
            this.SourceCardNumber = SourceCardNumber;
            this.DestinationCardNumber = DestinationCardNumber;
            this.Amount = Amount;
            this.TransferDate = TransferDate;
            this.isSuccessful = isSuccessful;
        }
        public Transaction()
        {
            
        }
    }


