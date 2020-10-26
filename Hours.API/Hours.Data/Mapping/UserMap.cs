using Hours.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hours.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(h => h.Id);

            builder.HasIndex(h => h.Email)
                .IsUnique();

            builder.Property(h => h.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Name)
                 .IsRequired()
                 .HasMaxLength(60);
        }
    }
}
