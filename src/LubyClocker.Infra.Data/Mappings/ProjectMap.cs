using LubyClocker.Domain.BoundedContexts.Developers;
using LubyClocker.Domain.BoundedContexts.Projects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LubyClocker.Infra.Data.Mappings
{
    public class ProjectMap : BaseEntityMap<Project>
    {
        protected override void ConfigureMap(EntityTypeBuilder<Project> builder)
        {
            builder
                .Property(c => c.Name)
                .HasMaxLength(160);
            
            builder
                .Property(c => c.Description);

            builder
                .Property(c => c.StartDate);
            
            builder
                .Property(c => c.DeliveryDate);
        }
    }
}