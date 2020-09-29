using LTS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LTS.Infra.Mappings
{
    public class DeveloperProjectMapping : IEntityTypeConfiguration<DeveloperProject>
    {
        public void Configure(EntityTypeBuilder<DeveloperProject> builder)
        {
            builder.HasKey(x => new { x.DeveloperId, x.ProjectId });
            builder.HasOne(x => x.Developer).WithMany(y => y.DeveloperProjects).HasForeignKey(x => x.DeveloperId);
            builder.HasOne(x => x.Project).WithMany(y => y.DeveloperProjects).HasForeignKey(x => x.ProjectId);
        }
    }
}
