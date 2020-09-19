using System;
using PontoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PontoAPI.Data.Mappings
{
    public class DesenvolvedorMapping : IEntityTypeConfiguration<Desenvolvedor>
    {
        public void Configure(EntityTypeBuilder<Desenvolvedor> builder)
        {
            builder.HasKey(t => t.DesenvolvedorID);
            builder.Property<int>(t => t.DesenvolvedorID).UseIdentityColumn(1, 1);
            builder.Property<string>(t => t.Nome);
            builder.Property<DateTime>(t => t.DataCadastro);

            builder.ToTable("TabDesenvolvedor");
        }
    }
}