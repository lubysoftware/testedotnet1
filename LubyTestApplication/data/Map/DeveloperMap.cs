using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test.domain.Entities;

namespace test.data.Map
{
    public class DeveloperMap : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developer");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.CreateAt).IsRequired();
            builder.Property(p => p.LastUpdate).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Password).IsRequired();

            builder.HasMany(c => c.Hours)
                .WithOne(c => c.Developer);

        }
    }
}
