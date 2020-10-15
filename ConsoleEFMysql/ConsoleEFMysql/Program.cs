using ConsoleEFMysql.Data;
using ConsoleEFMysql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleEFMysql
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            var contexto = new LivrariaContext();

            // inclusão
            /*
            LivroModel livro = new LivroModel() { Autor = "Nizzola", Lancamento = DateTime.Now, Nome = "Programando com C#", Preco = 10.00m , CodigoDeBarras = "789484848", ISBN = "1234"};
            contexto.Livros.Add(livro);
            contexto.SaveChanges();
            
            ClienteModel cli = new ClienteModel() { Nome = "Joao", Email = "joao@joao.com" };
            contexto.Clientes.Add(cli);
            contexto.SaveChanges();
            
            VendaModel venda = new VendaModel() { DataDaVenda = DateTime.Now, ClienteId = 1 };
            contexto.Vendas.Add(venda);
            contexto.SaveChanges();
            */

            var clientes = contexto.Clientes.ToList().OrderBy(apelidodatabela => apelidodatabela.Nome );

            Console.WriteLine("1º cliente:" + clientes.FirstOrDefault().Nome );

            Console.WriteLine("Ultimo cliente:" + clientes.LastOrDefault().Nome);

            Console.WriteLine("Cliente 10 :" + clientes.Where(x => x.ClienteId == 10).FirstOrDefault().Nome);
            Console.WriteLine("Cliente por nome :" + clientes.Where(x => x.Nome == "Samuel Prince" || x.Nome == "Kayky" ).FirstOrDefault().Nome);

            foreach (var item in clientes)
            {
                Console.WriteLine(item.Nome);
            }


            
            /*
            // consultar todos os livros
            var livros = contexto.Livros.ToList();
            foreach (var item in livros)
            {
                Console.WriteLine(item.Nome);
            }
            */

        }
    }
}
