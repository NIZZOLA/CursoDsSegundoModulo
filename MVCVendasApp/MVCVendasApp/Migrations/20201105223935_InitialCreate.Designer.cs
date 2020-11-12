﻿// <auto-generated />
using System;
using MVCVendasApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCVendasApp.Migrations
{
    [DbContext(typeof(MVCVendasAppContext))]
    [Migration("20201105223935_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVCVendasApp.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(80) CHARACTER SET utf8mb4")
                        .HasMaxLength(80);

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("MVCVendasApp.Models.ProdutoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodigoDeBarras")
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<decimal>("Estoque")
                        .HasColumnType("decimal(12,3)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("Unidade")
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MVCVendasApp.Models.VendaItensModel", b =>
                {
                    b.Property<int>("VendaItensId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDeVenda")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("VendaId")
                        .HasColumnType("int");

                    b.HasKey("VendaItensId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaItens");
                });

            modelBuilder.Entity("MVCVendasApp.Models.VendaModel", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoDoRastreamento")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("DataDaVenda")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataPrevistaDaEntrega")
                        .HasColumnType("datetime(6)");

                    b.HasKey("VendaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("MVCVendasApp.Models.VendaItensModel", b =>
                {
                    b.HasOne("MVCVendasApp.Models.ProdutoModel", "Produto")
                        .WithMany("ItensVendidos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCVendasApp.Models.VendaModel", "Venda")
                        .WithMany("Itens")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCVendasApp.Models.VendaModel", b =>
                {
                    b.HasOne("MVCVendasApp.Models.ClienteModel", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}