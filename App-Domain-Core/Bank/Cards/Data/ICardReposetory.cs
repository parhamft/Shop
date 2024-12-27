using App_Domain_Core.Bank.Cards.Services;
using quiz.Entities;

namespace quiz.Contracts
{
    public interface ICardReposetory
    {
        public bool create(Card c);
        public List<Card> GetAll();
        public Card GetById(string id);
        public bool update(Card c);
        public bool delete(string num);
        public bool Withdraw(string CardNum, float amount);
        public bool Deposit(string CardNum, float amount);
        public bool ChangePassword(string CardNum, string Password);


    }
}
