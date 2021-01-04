using LubyClocker.Domain.BoundedContexts.Developers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LubyClocker.Infra.Data.Mappings
{
    public class DeveloperMap : BaseEntityMap<Developer>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Developer> builder)
        {
            builder
                .Property(c => c.FullName)
                .HasMaxLength(160);
            
            builder
                .Property(c => c.Commentary);

            builder.Property(c => c.Qualification)
                .HasConversion(new EnumToStringConverter<QualificationLevel>());
        }
    }
}