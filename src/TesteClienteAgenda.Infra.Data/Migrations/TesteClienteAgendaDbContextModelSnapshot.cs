﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteClienteAgenda.Infra.Data.Context;

namespace TesteClienteAgenda.Infra.Data.Migrations
{
    [DbContext(typeof(TesteClienteAgendaDbContext))]
    partial class TesteClienteAgendaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TesteClienteAgenda.Domain.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLiquidacao")
                        .HasColumnName("data_liquidacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroTitulo")
                        .IsRequired()
                        .HasColumnName("num_titulo")
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<decimal>("Taxa")
                        .HasColumnName("taxa")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("ValorBruto")
                        .HasColumnName("valor_bruto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorLiquido")
                        .HasColumnName("valor_liquido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("agenda");
                });

            modelBuilder.Entity("TesteClienteAgenda.Domain.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Capital")
                        .HasColumnName("capital")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Classificacao")
                        .IsRequired()
                        .HasColumnName("classificacao")
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnName("cnpj")
                        .HasColumnType("varchar(14)")
                        .IsFixedLength(true)
                        .HasMaxLength(14);

                    b.Property<DateTime>("DataFundacao")
                        .HasColumnName("data_fundacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Quarentena")
                        .HasColumnName("quarentena")
                        .HasColumnType("bit");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("razao_social")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("StatusCliente")
                        .HasColumnName("status_cliente")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Cnpj", "RazaoSocial")
                        .IsUnique();

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("TesteClienteAgenda.Domain.Models.Agenda", b =>
                {
                    b.HasOne("TesteClienteAgenda.Domain.Models.Cliente", "Cliente")
                        .WithMany("Agendas")
                        .HasForeignKey("ClienteId")
                        .HasConstraintName("cliente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}