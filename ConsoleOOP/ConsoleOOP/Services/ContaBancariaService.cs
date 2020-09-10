using ConsoleOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleOOP.Services
{
    public class ContaBancariaService
    {

        public ContaBancaria CadastrarConta()
        {
            var tipo = this.PerguntarConta();
            ContaBancaria conta;
            if (tipo == "C")
                conta = this.CadastrarContaBancaria();
            else
                conta = this.CadastrarContaPoupanca();

            return conta;
        }

        private ContaBancaria CadastrarContaBancaria()
        {
            ContaBancaria conta = new ContaBancaria();
            conta.Agencia = Funcoes.ReceberNumero("Digite a agência:");
            conta.Conta = Funcoes.ReceberNumero("Digite o número da conta poupanca:");
            return conta;
        }

        private ContaBancaria CadastrarContaPoupanca()
        {
            ContaPoupanca conta = new ContaPoupanca();
            conta.Agencia = Funcoes.ReceberNumero("Digite a agência:");
            conta.Conta = Funcoes.ReceberNumero("Digite o número da conta poupanca:");
            conta.DiaDeAniversario = Funcoes.ReceberNumero("Digite o dia do aniversário:");

            return conta;
        }

        private string PerguntarConta()
        {
            string opcao;
            do
            {
                Console.WriteLine("Conta corrente ou poupança (C/P) ?");
                opcao = Console.ReadLine().ToUpper();
                if (opcao != "C" && opcao != "P")
                    Console.WriteLine("você deve digitar C ou P !");

            } while (opcao != "C" && opcao != "P");
            return opcao;
        }


        public void Sacar(ContaBancaria conta)
        {
            Console.WriteLine("Operação de saque na conta:" + conta.ExibirDados());
            var valor = Funcoes.ReceberDecimal("Digite o valor a sacar:");

            if( ! conta.Sacar(valor))
            {
                Console.WriteLine("Não foi possível sacar, saldo insuficiente!");
            }

            Console.WriteLine("O saldo atual é:" + conta.ConsultarSaldo());
            Console.ReadKey();
        }

        public void Depositar(ContaBancaria conta)
        {
            Console.WriteLine("Operação de depósito na conta:" + conta.ExibirDados());
            var valor = Funcoes.ReceberDecimal("Digite o valor a depositar:");

            conta.Depositar(valor);

            Console.WriteLine("O saldo atual é:" + conta.ConsultarSaldo());
            Console.ReadKey();
        }

        public ContaBancaria BuscarConta(List<ContaBancaria> contas)
        {
            int numeroAgencia, numeroConta;

            if (!contas.Any())
            {
                Console.WriteLine("Não existem contas cadastradas !");
                Console.ReadKey();
                return null;
            }

            numeroAgencia = Funcoes.ReceberNumero("Digite a agência:");
            numeroConta = Funcoes.ReceberNumero("Digite o número da conta:");


            var resultado = contas.Where(conta => conta.Agencia == numeroAgencia && conta.Conta == numeroConta).FirstOrDefault();

            return resultado;

        }

    }
}
