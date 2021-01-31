using ApiLuby.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiLuby.Infrastructure.Data.Mappings
{
    public class BankOfHoursMapping : IEntityTypeConfiguration<BankOfHours>
    {
        public void Configure(EntityTypeBuilder<BankOfHours> builder)
        {
            builder.ToTable("TB_BANKOFHOURS"); 

            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Codigo);
            builder.HasOne(p => p.Developer).WithMany().HasForeignKey(foreignKeyExpression => foreignKeyExpression.CodigoDeveloper);
            builder.Property(p => p.CodigoDeveloper);
            builder.Property(p => p.EntryDate);
            builder.Property(p => p.FinalDate);
            builder.Property(p => p.TotalHours);



        }
    }
}
