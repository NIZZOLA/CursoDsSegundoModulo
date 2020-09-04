using ConsoleOOP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Services
{
    public class ClienteService
    {
        public Cliente CadastrarCliente(string tipo )
        {
            Cliente cli;

            if (tipo == "")
            {
                Console.WriteLine("Pessoa física ou jurídica (F/J) ?");
                tipo = Console.ReadLine();
            }

            if (tipo == "F")
                cli = this.CadastrarFisica();
            else
                cli = this.CadastrarJuridica();

            return cli;
        }

        private ClientePessoaFisica CadastrarFisica()
        {
            var cli = new ClientePessoaFisica();
            Console.Write("Digite o nome do cliente:");
            cli.Nome = Console.ReadLine();

            Console.Write("Digite o CPF:");
            cli.Cpf = Console.ReadLine();

            Console.Write("Data do nascimento:");
            cli.DataDeNascimento = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite o Sexo <M/F> :");
            var sexo = Console.ReadLine();

            if (sexo.ToUpper() == "M")
                cli.Sexo = SexoEnum.Masculino;
            else
                cli.Sexo = SexoEnum.Feminino;

            return cli;
        }

        private ClientePessoaJuridica CadastrarJuridica()
        {
            var cli = new ClientePessoaJuridica();
            Console.Write("Digite o nome fantasia:");
            cli.NomeFantasia = Console.ReadLine();

            Console.Write("Razao Social:");
            cli.RazaoSocial = Console.ReadLine();

            Console.Write("CNPJ:");
            cli.CNPJ = Console.ReadLine();

            Console.Write("Inscrição estadual:");
            cli.InscricaoEstadual = Console.ReadLine();

            Console.Write("Data de fundação:");
            cli.DataDaFundacao = DateTime.Parse(Console.ReadLine());

            return cli;
        }

    }
}
