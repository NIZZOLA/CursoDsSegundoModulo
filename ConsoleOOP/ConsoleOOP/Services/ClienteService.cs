using ConsoleOOP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Services
{
    public class ClienteService
    {
        public ClientePessoaFisica CadastrarFisica()
        {
            ClientePessoaFisica cli = new ClientePessoaFisica();
            Console.Write("Digite o nome do cliente:");
            cli.Nome = Console.ReadLine();

            return cli;
        }

        


        public void Processar()
        {

            var cli = new ClientePessoaFisica()
            {
                ClienteId = 1,
                Cpf = "123456",
                Nome = "JOSE DA SILVA",
                Sexo = SexoEnum.Masculino
            };

            var empresa = new ClientePessoaJuridica()
            {
                ClienteId = 2,
                CNPJ = "111111",
                NomeFantasia = "ETEC ITU"
            };

            var conta = new ContaBancaria()
            {
                Agencia = 1,
                Conta = 345,
                ContaBancariaId = 1,
                DataDaAbertura = DateTime.Now,
                Titular1 = cli
            };

            var poupanca = new ContaPoupanca()
            {
                Agencia = 1,
                Conta = 345,
                ContaBancariaId = 1,
                DataDaAbertura = DateTime.Now,
                Titular1 = empresa,
                DiaDeAniversario = 10
            };

            ClientePessoaJuridica titular = (ClientePessoaJuridica)poupanca.Titular1;


            string texto = $"\n Agencia {poupanca.Agencia} Conta: {poupanca.Conta} Titular: {titular.NomeFantasia} " +
                           $" Razao social: { ((ClientePessoaJuridica)poupanca.Titular1).RazaoSocial} ";

            Console.Write("Saldo inicial:" + poupanca.ConsultarSaldo());

            poupanca.Depositar(1000);

            poupanca.Sacar(300);
            poupanca.Sacar(1.99m);
            poupanca.Depositar(10);



            foreach (var item in poupanca.Movimentacao)
            {
                Console.WriteLine($"| {item.Data} | {item.Tipo} | {item.Valor} |");
            }

            Console.Write("Saldo atual:" + poupanca.ConsultarSaldo());


        }


    }
}
