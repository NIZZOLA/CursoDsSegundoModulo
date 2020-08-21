using ConsoleApp2.Models;
using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");

            Produto prod = new Produto();
            prod.Codigo = 1;
            prod.Descricao = "Batata frita";
            prod.UnidadeDeMedida = "kg";
            

            var prod2 = new Produto();
            prod2.Codigo = 2;
            prod2.Descricao = "Milk Shake";
            prod2.UnidadeDeMedida = "un";

            var prod3 = new Produto() { Codigo = 3, Descricao = "HAMBURGUER", UnidadeDeMedida = "UN" };

            double margem = 30.99;

            var prod4 = new Produto(4, "PIZZA", "UN", 18.5M , (decimal) margem );

            List<Produto> lista = new List<Produto>();
            lista.Add(prod);
            lista.Add(prod2);
            lista.Add(prod3);
            lista.Add(prod4);

            var objTela = new Tela2();
            
            foreach (var item in lista)
            {
                Tela.MontaTela(item);

                objTela.MontaTela(item);

            }
            
            var kayky = new Pessoa() { Cpf = "111.222.333-44", Nome = "KAYKY" };

            var conta = new ContaPadrao();
            conta.Agencia = 1;
            conta.Numero = 123;
            conta.Correntista = kayky;

            Console.WriteLine($"Agencia: {conta.Agencia} Conta: {conta.Numero} Titular: {conta.Correntista.Nome} cpf: {conta.Correntista.Cpf} ");
            */

            int opcao = 0;
            ContaPadrao conta = new ContaPadrao();
            do
            {
                Tela.Menu();
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Tela.CriarConta(conta);
                        break;
                    case 2:
                        Tela.Depositar(conta);
                        break;
                    case 3:
                        Tela.Sacar(conta);
                        break;
                    case 4:
                        Tela.VerSaldo(conta);
                        break;
                    default:
                        Console.WriteLine("Opção incorreta !");
                        break;
                }


            } while (opcao != 0);



        }




    }
}
