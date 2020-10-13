namespace Luby.Data.Mapping
{
    using Luby.Core.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjetoDesenvolvedoresMapping : IEntityTypeConfiguration<ProjetoDesenvolvedores>
    {
        public void Configure(EntityTypeBuilder<ProjetoDesenvolvedores> builder)
        {
            builder.ToTable("ProjetoDesenvolvedores");

            builder.HasKey(p => new { p.DesenvolvedorId, p.ProjetoId } );

            builder.HasOne<Projeto>(p => p.Projeto)
                .WithMany(p => p.ProjetoDesenvolvedor)
                .HasForeignKey(p => p.ProjetoId);

            builder.HasOne<Desenvolvedor>(p => p.Desenvolvedor)
                .WithMany(p => p.ProjetoDesenvolvedor)
                .HasForeignKey(p => p.DesenvolvedorId);

            builder.Property(p => p.DtFim)
                .IsRequired()
                .HasColumnType("datetime2");

            builder.Property(p => p.DtInicio)
                .IsRequired()
                .HasColumnType("datetime2");
        }
    }
}