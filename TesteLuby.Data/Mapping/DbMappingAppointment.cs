using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TesteLuby.Data.Entities;

namespace TesteLuby.Data.Mapping
{
    public class DbMappingAppointment : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(x => x.ID)
                   .HasName("ID");

            builder.Property(x => x.Date_Start)
                   .HasColumnName("Date_Start")
                   .HasColumnType("datetime")
                   .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Date_End)
                  .HasColumnName("Date_End")
                  .HasColumnType("datetime")
                  .HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.Project)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.ProjectID);

            builder.HasOne(x => x.Developer)
                   .WithMany(x => x.Appointments)
                   .HasForeignKey(x => x.DeveloperID);
        }
    }
}
