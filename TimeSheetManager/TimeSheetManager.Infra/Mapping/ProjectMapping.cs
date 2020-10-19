using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheetManager.Domain.Entities.Project;

namespace TimeSheetManager.Infra.Mapping {
    public class ProjectMapping : IEntityTypeConfiguration<Project>{ 
        public void Configure(EntityTypeBuilder<Project> builder){
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}