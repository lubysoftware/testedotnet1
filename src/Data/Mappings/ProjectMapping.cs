using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projeto");

            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .IsRequired(true);

            builder.Property(x => x.Name)
                .HasColumnName("Nome")
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(x => x.Concluded)
                .HasColumnName("Concluido")
                .HasColumnType("bit")
                .IsRequired(false);

            builder.Property(x => x.StartDate)
                .HasColumnName("DataInicio")
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(x => x.EndDate)
                .HasColumnName("DataFinal")
                .HasColumnType("DateTime")
                .IsRequired(false);

        }
    }
}
