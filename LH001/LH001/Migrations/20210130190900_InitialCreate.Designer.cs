using System;
using LH001.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LH001.Migrations
{
    [DbContext(typeof(BdContext))]
    [Migration("20210130190900_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("LH001.Domain.Entidades.Tb_Desenvolvedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tb_Desenvolvedores");
                });

            modelBuilder.Entity("LH001.Domain.Entidades.Tb_Desenvolvedor_Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Tb_DesenvolvedorId")
                        .HasColumnType("int");

                    b.Property<int>("Tb_ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Tb_DesenvolvedorId");

                    b.HasIndex("Tb_ProjetoId");

                    b.ToTable("Tb_Desenvolvedores_Projetos");
                });

            modelBuilder.Entity("LH001.Domain.Entidades.Tb_LancamentoHoras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Horas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tb_Desenvolvedor_ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Tb_Desenvolvedor_ProjetoId");

                    b.ToTable("Tb_LancamentosHoras");
                });

            modelBuilder.Entity("LH001.Domain.Entidades.Tb_Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tb_Projetos");
                });

            modelBuilder.Entity("LH001.Domain.Entidades.Tb_Desenvolvedor_Projeto", b =>
                {
                    b.HasOne("LH001.Domain.Entidades.Tb_Desenvolvedor", "Tb_Desenvolvedor")
                        .WithMany()
                        .HasForeignKey("Tb_DesenvolvedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LH001.Domain.Entidades.Tb_Projeto", "Tb_Projeto")
                        .WithMany()
                        .HasForeignKey("Tb_ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tb_Desenvolvedor");

                    b.Navigation("Tb_Projeto");
                });

            modelBuilder.Entity("LH001.Domain.Entidades.Tb_LancamentoHoras", b =>
                {
                    b.HasOne("LH001.Domain.Entidades.Tb_Desenvolvedor_Projeto", "Tb_Desenvolvedor_Projeto")
                        .WithMany()
                        .HasForeignKey("Tb_Desenvolvedor_ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tb_Desenvolvedor_Projeto");
                });
#pragma warning restore 612, 618
        }
    }
}
