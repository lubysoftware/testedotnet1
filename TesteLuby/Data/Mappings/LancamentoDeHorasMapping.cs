using Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class LancamentoDeHorasMapping : IEntityTypeConfiguration<LancamentoDeHora>
    {
        public void Configure(EntityTypeBuilder<LancamentoDeHora> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.HoraInicio)
                .IsRequired()
                .HasColumnType("TIMESTAMP");

            builder.Property(l => l.HoraFim)
                .IsRequired()
                .HasColumnType("TIMESTAMP");

            builder.ToTable("Lancamentos");
        }
    }
}