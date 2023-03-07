using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SchoolERP.Data.Models.Maping
{
    public class GuardianRelationMap : IEntityTypeConfiguration<GuardianRelation>
    {
        public void Configure(EntityTypeBuilder<GuardianRelation> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd().IsRequired();//.HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
            builder.Property(o => o.Name).HasMaxLength(50);
            builder.ToTable("GuardianRelation");
        }
    }
}
