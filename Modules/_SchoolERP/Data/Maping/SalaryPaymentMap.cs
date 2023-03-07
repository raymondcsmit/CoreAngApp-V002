using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    
    public class SalaryPaymentMap : IEntityTypeConfiguration<SalaryPayment> 
    {
        public void Configure(EntityTypeBuilder<SalaryPayment> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.HasOne(c => c.SalaryGrade_SalaryGradeId).WithMany(o => o.SalaryPayment_SalaryGradeIds).HasForeignKey(o => o.SalaryGradeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.PaymentMethod_PaymentMethodId).WithMany(o => o.SalaryPayment_PaymentMethodIds).HasForeignKey(o => o.PaymentMethodId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.LedgerHead_ExpenseId).WithMany(o => o.SalaryPayment_ExpenseIds).HasForeignKey(o => o.ExpenseId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(o => o.Note).HasMaxLength(100);
             builder.ToTable("SalaryPayment");
 

        }
    }
}
