using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(o => o.FromSchool).HasMaxLength(500);
            builder.HasOne(c => c.Student_ToStudentId).WithMany(o => o.Invoice_ToStudentIds).HasForeignKey(o => o.ToStudentId).OnDelete(DeleteBehavior.NoAction);//.WillCascadeOnDelete(false);
            builder.HasOne(c => c.PaymentMethod_PaymentMethodId).WithMany(o => o.Invoice_PaymentMethodIds).HasForeignKey(o => o.PaymentMethodId);
            builder.Property(o => o.PaymentStatus).HasMaxLength(100);
            builder.Property(o => o.FeesHead).HasMaxLength(100);
            builder.ToTable("Invoice");
 

        }
    }
}
