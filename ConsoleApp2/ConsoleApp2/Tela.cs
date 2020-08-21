using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public static class Tela
    {
        public static void MontaTela(Produto prod)
        {
            Console.Write($"\nCodigo: {prod.Codigo} \nDescrição: {prod.Descricao} \nUnidade de Medida: {prod.UnidadeDeMedida} "
                        + $"\nPreço: {prod.ValorDeVenda()} \n");
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Digite a opção desejada:\n 1-Criar conta \n 2-Depositar \n 3-Sacar \n 4-Ver Saldo \n 0-Finalizar");
        }

        public static void CriarConta( ContaPadrao cta )
        {
            Console.Clear();
            Console.Write("Digite o número da agência:");
            cta.Agencia = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o número da conta:");
            cta.Numero = Convert.ToInt32(Console.ReadLine());

            var pessoa = new Pessoa();
            Console.Write("Digite o nome do correntista:");
            pessoa.Nome = Console.ReadLine();

            Console.Write("Digite o número do cpf:");
            pessoa.Cpf = Console.ReadLine();

            cta.Correntista = pessoa;
        }

        public static void VerSaldo(ContaPadrao cta)
        {
            Console.WriteLine("Seu saldo atual é:" + cta.VerSaldo());
            Pausar();
        }

        public static void Sacar(ContaPadrao cta)
        {
            Console.Clear();
            Console.WriteLine("Seu saldo é:" + cta.VerSaldo());

            Console.Write("SAQUE NA CONTA \n Digite o valor desejado:");
            decimal valor = Convert.ToDecimal(Console.ReadLine());

            if (cta.Sacar(valor) == false)
                Console.WriteLine("Não foi possível sacar, saldo insuficiente !");

            Console.WriteLine("Seu novo saldo é:" + cta.VerSaldo());
            Pausar();
        }

        public static void Depositar(ContaPadrao cta )
        {
            Console.Clear();
            Console.Write("DEPÓSITO NA CONTA \n Digite o valor desejado:");
            decimal valor = Convert.ToDecimal( Console.ReadLine() );

            cta.Depositar(valor);

            Console.WriteLine("Seu novo saldo é:" + cta.VerSaldo());
            Pausar();
        }

        public static void Pausar()
        {
            Console.Write("Pressione qualquer tecla !");
            Console.ReadKey();
        }

    }
}
