using System;
using PontoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PontoAPI.Data.Mappings
{
    public class ProjetoMapping : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.HasKey(t => t.ProjetoID);
            builder.Property<int>(t => t.ProjetoID).UseIdentityColumn(1, 1);
            builder.Property<string>(t => t.NomeProjeto);
            builder.Property<DateTime>(t => t.DataCadastro);
            builder.Property<bool>(t => t.Ativo);

            builder.ToTable("TabProjeto");
        }
    }
}