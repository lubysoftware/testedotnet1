﻿// <auto-generated />
using System;
using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    [DbContext(typeof(LancadorContext))]
    [Migration("20200813221708_campos trocados em horas")]
    partial class campostrocadosemhoras
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Lançador_de_Horas_WebAPI.Models.Desenvolvedor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Desenvolvedores");
                });

            modelBuilder.Entity("Lançador_de_Horas_WebAPI.Models.Projeto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Custo")
                        .HasColumnType("double");

                    b.Property<string>("NomeDoProjeto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Lançador_de_Horas_WebAPI.Models.RegistroDeHoras", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DesenvolvedorId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TotalHoras")
                        .HasColumnType("time(6)");

                    b.HasKey("ID");

                    b.HasIndex("DesenvolvedorId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("RegistrosDeHoras");
                });

            modelBuilder.Entity("Lançador_de_Horas_WebAPI.Models.RegistroDeHoras", b =>
                {
                    b.HasOne("Lançador_de_Horas_WebAPI.Models.Desenvolvedor", "Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("DesenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lançador_de_Horas_WebAPI.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
