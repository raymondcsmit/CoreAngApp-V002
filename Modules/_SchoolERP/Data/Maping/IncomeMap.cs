using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class IncomeMap : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
             builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.LedgerHead_IncomeHeadId).WithMany(o => o.Income_IncomeHeadIds).HasForeignKey(o => o.IncomeHeadId).OnDelete(DeleteBehavior.NoAction);//.WillCascadeOnDelete(false);
            builder.HasOne(c => c.PaymentMethod_PaymentMethodId).WithMany(o => o.Income_PaymentMethodIds).HasForeignKey(o => o.PaymentMethodId).OnDelete(DeleteBehavior.NoAction); //WillCascadeOnDelete(false);
            builder.HasOne(c => c.SessionYear_RunningYearId).WithMany(o => o.Income_RunningYearIds).HasForeignKey(o => o.RunningYearId).OnDelete(DeleteBehavior.NoAction); //WillCascadeOnDelete(false);
            builder.Property(o => o.Note).HasMaxLength(100);
            builder.ToTable("Income");
 

        }
    }
}
