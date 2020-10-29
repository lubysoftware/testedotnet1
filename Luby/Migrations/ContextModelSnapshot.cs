﻿// <auto-generated />
using System;
using Luby.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Luby.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Luby.Models.Desenvolvedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Senha")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Desenvolvedor");
                });

            modelBuilder.Entity("Luby.Models.LancamentoHora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DesenvolvedorId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DesenvolvedorId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("LancamentoHora");
                });

            modelBuilder.Entity("Luby.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("Luby.Models.LancamentoHora", b =>
                {
                    b.HasOne("Luby.Models.Desenvolvedor", "Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("DesenvolvedorId");

                    b.HasOne("Luby.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId");
                });
#pragma warning restore 612, 618
        }
    }
}
