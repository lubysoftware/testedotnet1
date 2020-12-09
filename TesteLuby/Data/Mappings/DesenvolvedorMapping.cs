using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class DesenvolvedorMapping : IEntityTypeConfiguration<Desenvolvedor>
    {
        public void Configure(EntityTypeBuilder<Desenvolvedor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(d => d.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            //
            // builder.Property(p => p.Imagem)
            //     .IsRequired()
            //     .HasColumnType("varchar(100)");

            builder.ToTable("Desenvolvedores");
        }
    }
}