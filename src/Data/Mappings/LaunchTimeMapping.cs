using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class LaunchTimeMapping : IEntityTypeConfiguration<LaunchTime>
    {
        public void Configure(EntityTypeBuilder<LaunchTime> builder)
        {
            builder.ToTable("LancamentoHora");

            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .IsRequired(true);

            builder.Property(x => x.RegisterDate)
                .HasColumnName("DataRegistro")
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(x => x.Initial)
                .HasColumnName("DataHoraInicio")
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(x => x.End)
                .HasColumnName("DataHoraFinal")
                .HasColumnType("DateTime")
                .IsRequired(true);

            builder.Property(x => x.IdDeveloper)
                .HasColumnName("IdDesenvolvedor")
                .HasColumnType("uniqueidentifier");


            builder.HasOne(x => x.Developer)
                .WithMany(y => y.LaunchTimes)
                .HasForeignKey(x => x.IdDeveloper)
                .HasConstraintName("FK_IdDesenvolvedor")
                .IsRequired(true);

            builder.HasOne(x => x.Project)
                .WithMany(y => y.LaunchTimes)
                .HasForeignKey(x => x.IdProject)
                .HasConstraintName("FK_IdProjeto")
                .IsRequired(true);
            
        }
    }
}
