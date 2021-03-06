﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mundo.Api.Pessoas.Data;

namespace Mundo.Api.Pessoas.Migrations
{
    [DbContext(typeof(MundoApiPessoasContext))]
    [Migration("20200924205115_RelacionamentoAmigo")]
    partial class RelacionamentoAmigo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mundo.Api.Pessoas.Domain.Pessoas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAniversario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id_EstadoOrigem")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_PaisOrigiem")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PessoasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlFoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PessoasId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Mundo.Api.Pessoas.Domain.Pessoas", b =>
                {
                    b.HasOne("Mundo.Api.Pessoas.Domain.Pessoas", null)
                        .WithMany("Amigos")
                        .HasForeignKey("PessoasId");
                });
#pragma warning restore 612, 618
        }
    }
}
