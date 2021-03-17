using LTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LTS.Infra.Mappings
{
    public class DeveloperMapping : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(n => n.Name).IsRequired().HasMaxLength(60);
            builder.Property(a => a.Age).IsRequired().HasMaxLength(2);
            builder.HasMany(x => x.TimeSheets).WithOne(y => y.Developer);
        }
    }
}
