using quiz.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace App_Domain_Core.Bank.Cards.Services
{
    public class Card
    {
        [Key]
        public string CardNumber { get; set; }
        [MaxLength(20)]
        public string HolderName { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }
        public float Balance{ get; set; }
        public int tries { get; set; } = 0;
        public bool IsActive{ get; set; }
        [MaxLength(20)]
        public string Password{ get; set; }
        [NotMapped]
        public List<Transaction> SentTransactions { get; set; }
        [NotMapped]
        public List<Transaction> RecievedTransactions { get; set; }
        

    }
}
