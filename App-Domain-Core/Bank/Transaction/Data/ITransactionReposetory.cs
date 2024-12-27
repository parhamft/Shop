using quiz.Entities;

namespace quiz.Contracts
{
    public interface ITransactionReposetory
    {
        public bool create(Transaction t);
        public List<Transaction> GetAll();
        public List<Transaction> GetAllReports(string cardnum);
        public Transaction GetById(int id);
        public bool update(Transaction t);
        public bool delete(int id);
    }
}
