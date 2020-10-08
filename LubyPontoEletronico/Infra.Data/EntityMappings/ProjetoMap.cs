using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.EntityMappings
{
    public class ProjetoMap : MapBase<Projeto>
    {
        public override void Configure(EntityTypeBuilder<Projeto> builder)
        {
            base.Configure(builder);
            builder.ToTable("projeto");
            builder.Property(c => c.Nome).IsRequired().HasColumnName("Nome");

            builder.HasMany(c => c.Pessoas).WithOne(c => c.Projeto).HasForeignKey(x => x.IdProjeto);
        }
    }
}
