using App_Domain_Core.Bank.Cards.Services;
using Microsoft.EntityFrameworkCore;

using quiz.Contracts;


namespace quiz.reposetories
{
    public class CardReposetory : ICardReposetory
    {

        private readonly BankDBContext _dbContext;
        public CardReposetory(BankDBContext dbContext)
        {
            _dbContext=dbContext;
        }
        public bool create(Card c)
        {
            _dbContext.Cards.Add(c);
            _dbContext.SaveChanges();
            return true;
        }

        public bool delete(string num)
        {
            Card c=_dbContext.Cards.FirstOrDefault(x=>x.CardNumber==num);
            if (c==null) return false;
            _dbContext.Cards.Remove(c);
            _dbContext.SaveChanges();
            return true;

        }



        public List<Card> GetAll()
        {
            return _dbContext.Cards.AsNoTracking().ToList();
        }

        public Card GetById(string id)
        {
            return _dbContext.Cards.AsNoTracking().FirstOrDefault(x => x.CardNumber == id);
        }

        public bool Withdraw(string CardNum,float amount)
        {
            var card=_dbContext.Cards.FirstOrDefault(x => x.CardNumber == CardNum);
            if (card==null) return false;
            card.Balance = card.Balance-amount;
            _dbContext.SaveChanges();
            return true;
        }
        public bool Deposit(string CardNum, float amount)
        {
            var card=_dbContext.Cards.FirstOrDefault( x => x.CardNumber == CardNum);
            if (card == null) return false;
            card.Balance = card.Balance + amount;
            _dbContext.SaveChanges();
            return true;
        }

        public bool update(Card c)
        {
            _dbContext.Cards.Update(c);
            _dbContext.SaveChanges();
            return true;

        }

        public bool ChangePassword(string CardNum, string Password)
        {
            var card = _dbContext.Cards.FirstOrDefault(x => x.CardNumber == CardNum);
            if (card == null) return false;
            card.Password=Password;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
