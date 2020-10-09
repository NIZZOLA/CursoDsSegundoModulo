﻿// <auto-generated />
using System;
using ConsoleEFMysql.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleEFMysql.Migrations
{
    [DbContext(typeof(LivrariaContext))]
    [Migration("20201009221922_InicialCreate")]
    partial class InicialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ConsoleEFMysql.Models.LivroModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("CodigoDeBarras")
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(13) CHARACTER SET utf8mb4")
                        .HasMaxLength(13);

                    b.Property<DateTime>("Lancamento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.ToTable("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
