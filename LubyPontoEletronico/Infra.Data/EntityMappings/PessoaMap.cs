using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityMappings
{
    public class PessoaMap : MapBase<Pessoa>
    {
        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder);
            builder.ToTable("pessoa");
            builder.Property(c => c.Nome).IsRequired().HasColumnName("Nome");
            builder.Property(c => c.Email).IsRequired().HasColumnName("Email");
            builder.Property(c => c.Senha).IsRequired().HasColumnName("Senha");
            builder.Property(c => c.IdProjeto).HasColumnName("IdProjeto");
            builder.Property(c => c.TipoPessoa).HasColumnName("TipoPessoa");

            builder.HasOne(c => c.Projeto).WithMany(c => c.Pessoas).HasForeignKey(x => x.IdProjeto);
            builder.HasMany(c => c.Pontos).WithOne(c => c.Pessoa).HasForeignKey(x => x.IdPessoa);
        }
    }
}
