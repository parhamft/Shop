using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using quiz.Entities;


namespace quiz.Configs
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
       

        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(x => x.Card).WithMany(y => y.SentTransactions).HasForeignKey(x => x.SourceCardNumber).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DCard).WithMany(y => y.RecievedTransactions).HasForeignKey(x => x.DestinationCardNumber).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.SourceCardNumber).IsRequired().HasColumnType("nchar(16)");
            builder.Property(x => x.DestinationCardNumber).IsRequired().HasColumnType("nchar(16)");


        }

    }
}
