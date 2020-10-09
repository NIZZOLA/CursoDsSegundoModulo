using ConsoleEFMysql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEFMysql.Data
{
    public class LivrariaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = "Server=localhost;DataBase=Livraria;Uid=root;Pwd=";

            optionsBuilder.UseMySql(conexao);
        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }
        public DbSet<VendaItensModel> VendaItens { get; set; }

    }
}
