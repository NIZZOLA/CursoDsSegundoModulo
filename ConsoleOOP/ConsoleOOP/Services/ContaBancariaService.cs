using ConsoleOOP.Models;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("Digite o número da conta:");
            //TODO - falta receber todos os atributos da conta

            return conta;
        }

        private ContaBancaria CadastrarContaPoupanca()
        {
            ContaPoupanca conta = new ContaPoupanca();
            //TODO - falta receber todos os atributos da conta

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

            } while (opcao == "C" || opcao == "P");
            return opcao;
        }


        public void Sacar()
        {

        }

        public void Depositar()
        {

        }

    }
}
