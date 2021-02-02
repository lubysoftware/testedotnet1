﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiLuby.Context;

namespace apiLuby.Migrations
{
    [DbContext(typeof(MSSQLContext))]
    [Migration("20210201225026_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("apiLuby.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeveloperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdDeveloper")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("apiLuby.Models.Developer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid>("IdAppointment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("apiLuby.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeveloperId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EstimatedHours")
                        .HasColumnType("int");

                    b.Property<Guid>("IdAppointment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("apiLuby.Models.Appointment", b =>
                {
                    b.HasOne("apiLuby.Models.Developer", "Developer")
                        .WithMany("Appointments")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("apiLuby.Models.Project", "Project")
                        .WithMany("Appointment")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Developer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("apiLuby.Models.Project", b =>
                {
                    b.HasOne("apiLuby.Models.Developer", null)
                        .WithMany("Projects")
                        .HasForeignKey("DeveloperId");
                });

            modelBuilder.Entity("apiLuby.Models.Developer", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("apiLuby.Models.Project", b =>
                {
                    b.Navigation("Appointment");
                });
#pragma warning restore 612, 618
        }
    }
}
