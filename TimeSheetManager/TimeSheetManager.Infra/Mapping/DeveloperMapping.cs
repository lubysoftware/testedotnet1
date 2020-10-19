using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheetManager.Domain.Entities.Developer;

namespace TimeSheetManager.Infra.Mapping {
    public class DeveloperMapping : IEntityTypeConfiguration<Developer>{ 
        public void Configure(EntityTypeBuilder<Developer> builder){
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}