using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityMappings
{
    public class PontoMap : MapBase<Ponto>
    {
        public override void Configure(EntityTypeBuilder<Ponto> builder)
        {
            base.Configure(builder);
            builder.ToTable("ponto");
            builder.Property(c => c.DataInicio).IsRequired().HasColumnName("DataInicio");
            builder.Property(c => c.DataFim).HasColumnName("DataInicio");
            builder.Property(c => c.IdPessoa).HasColumnName("IdPessoa");

            builder.HasOne(c => c.Pessoa).WithMany(c => c.Pontos).HasForeignKey("ÌdPessoa");
        }
    }
}
