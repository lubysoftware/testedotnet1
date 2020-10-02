using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento do desenvolvedor
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 21/09/2020
    /// </remarks>
    public class DeveloperMapping : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Desenvolvedor");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("varchar(200)")
                .IsRequired(true);

            builder.Property(x => x.Uf)
                .HasColumnName("Uf")
                .HasColumnType("varchar(2)")
                .IsRequired(true);
        }
    }
}
