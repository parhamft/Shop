using App_Domain_Core.Bank;
using App_Domain_Core.Bank.Cards.Services;
using Microsoft.EntityFrameworkCore;
using quiz.Configs;
using quiz.Entities;


namespace quiz.reposetories
{
    public class BankDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-03R7JG5\\SQLEXPRESS; Database=Bank;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new TransactionConfig());

        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> transactions { get; set; }

    }
}
