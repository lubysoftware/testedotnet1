namespace Luby.Data.Mapping
{
    using Luby.Core.Model;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(255)");
        }
    }
}