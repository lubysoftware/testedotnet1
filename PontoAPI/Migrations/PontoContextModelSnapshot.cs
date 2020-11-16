﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PontoAPI.Data;

namespace PontoAPI.Migrations
{
    [DbContext(typeof(PontoContext))]
    partial class PontoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PontoAPI.Domain.Models.Desenvolvedor", b =>
                {
                    b.Property<int>("DesenvolvedorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesenvolvedorID");

                    b.ToTable("TabDesenvolvedor");
                });

            modelBuilder.Entity("PontoAPI.Domain.Models.Lancamento", b =>
                {
                    b.Property<int>("LancamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DesenvolvedorID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("HoraFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProjetoID")
                        .HasColumnType("int");

                    b.HasKey("LancamentoID");

                    b.HasIndex("DesenvolvedorID");

                    b.HasIndex("ProjetoID");

                    b.ToTable("TabLancamento");
                });

            modelBuilder.Entity("PontoAPI.Domain.Models.Projeto", b =>
                {
                    b.Property<int>("ProjetoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeProjeto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjetoID");

                    b.ToTable("TabProjeto");
                });

            modelBuilder.Entity("PontoAPI.Domain.Models.Lancamento", b =>
                {
                    b.HasOne("PontoAPI.Domain.Models.Desenvolvedor", "Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("DesenvolvedorID");

                    b.HasOne("PontoAPI.Domain.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoID");
                });
#pragma warning restore 612, 618
        }
    }
}
