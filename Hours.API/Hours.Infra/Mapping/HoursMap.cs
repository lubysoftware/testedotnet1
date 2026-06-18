using Hours.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hours.Infra.Mapping
{
    public class HoursMap : IEntityTypeConfiguration<HoursEntity>
    {
        public void Configure(EntityTypeBuilder<HoursEntity> builder)
        {
            builder.ToTable("Hours");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.StartDate)
                .IsRequired();

            builder.Property(h => h.EndDate)
                .IsRequired();
        }
    }
}
