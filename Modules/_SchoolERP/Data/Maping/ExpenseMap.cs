using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.LedgerHead_ExpenseHeadId).WithMany(o => o.Expense_ExpenseHeadIds).HasForeignKey(o => o.ExpenseHeadId).OnDelete(DeleteBehavior.NoAction);// WillCascadeOnDelete(false);
            builder.HasOne(c => c.PaymentMethod_PaymentMethodId).WithMany(o => o.Expense_PaymentMethodIds).HasForeignKey(o => o.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);//.WillCascadeOnDelete(false);
            builder.Property(o => o.Note).HasMaxLength(100);
            builder.ToTable("Expense");
 

        }
    }
}
