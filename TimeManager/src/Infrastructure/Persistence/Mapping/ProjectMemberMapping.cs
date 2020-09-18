using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeManager.Domain.Projects.ProjectMembers;

namespace TimeManager.Infrastructure.Persistence.Mapping
{
    public class ProjectMemberMapping : IEntityTypeConfiguration<ProjectMember>
    {

        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(c => c.StartedAt)
                .IsRequired();

            builder
                .HasOne(c => c.Developer)
                .WithMany(c => c.Projects)
                .HasForeignKey(c => c.DeveloperId);

            builder
                .HasOne(c => c.Project)
                .WithMany(c => c.Members)
                .HasForeignKey(c => c.ProjectId);
        }
    }
}
