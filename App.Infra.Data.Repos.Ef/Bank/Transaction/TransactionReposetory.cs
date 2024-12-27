using Microsoft.EntityFrameworkCore;
using quiz.Contracts;
using quiz.Entities;

namespace quiz.reposetories
{
    public class TransactionReposetory : ITransactionReposetory
    {
        BankDBContext _dbContext = new BankDBContext();
        public bool create(Transaction t)
        {
            _dbContext.transactions.Add(t);
            _dbContext.SaveChanges();
            return true;
        }

        public bool delete(int id)
        {
            Transaction t = _dbContext.transactions.FirstOrDefault(x => x.Id == id);
            if (t == null) return false;
            _dbContext.transactions.Remove(t);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Transaction> GetAll()
        {
            return _dbContext.transactions.AsNoTracking().ToList();
        }

        public List<Transaction> GetAllReports(string cardnum)
        {
            List<Transaction> result = _dbContext.transactions.AsNoTracking().Where(x=>x.DestinationCardNumber==cardnum ||x.SourceCardNumber==cardnum).ToList();
            return result;
        }

        public Transaction GetById(int id)
        {
            return _dbContext.transactions.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public bool update(Transaction t)
        {
            _dbContext.transactions.Update(t);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
