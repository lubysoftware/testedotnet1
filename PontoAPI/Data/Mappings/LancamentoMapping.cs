using System;
using PontoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PontoAPI.Data.Mappings
{
    public class LancamentoMapping : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(t => t.LancamentoID);
            builder.Property<int>(t => t.LancamentoID).UseIdentityColumn(1, 1);
            builder.HasOne<Desenvolvedor>(t => t.Desenvolvedor);
            builder.HasOne<Projeto>(t => t.Projeto);
            builder.Property<DateTime>(t => t.HoraInicio);
            builder.Property<DateTime?>(t => t.HoraFim);

            builder.ToTable("TabLancamento");
        }
    }
}