using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeManager.Domain.Developers;

namespace TimeManager.Infrastructure.Persistence.Mapping
{
    public class DeveloperMapping : IEntityTypeConfiguration<Developer>
    { 

        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
