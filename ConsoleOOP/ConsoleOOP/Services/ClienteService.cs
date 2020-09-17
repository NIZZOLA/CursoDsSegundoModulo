using ConsoleOOP.Models;
using ConsoleOOP.Repositoryes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

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

            
            if (tipo.ToUpper() == "F")
                cli = this.CadastrarFisica();
            else
                cli = this.CadastrarJuridica();

            FileRepository.Gravar("clientes.data", cli.PrepararDados() );

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

            cli.DataDoCadastro = DateTime.Now;

            FileRepository.Gravar("cliente" + cli.Cpf + ".json", JsonSerializer.Serialize(cli));

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

        /* antes de otimizar o método
        public List<Cliente> CarregarArquivo()
        {
            // Prepara uma lista vazia de clientes para devolver preenchida
            List<Cliente> clientes = new List<Cliente>();

            // chama a classe estatica de leitura e recebe uma lista de strings
            var retorno = FileRepository.Ler("clientes.data");

            if( retorno.Any() ) // verifica se houve algum item no retorno
            {
                foreach (var linha in retorno) // percorre os itens do retorno e cria a variavel string linha
                {
                    var itensLinha = linha.Split(";"); //faz um array com o string Linha onde separa cada elemento por um ; 
                    if(itensLinha[0]== "F")
                    {
                        var cli = new ClientePessoaFisica();
                        cli.ClienteId = Convert.ToInt32(itensLinha[1]);
                        cli.Cpf = itensLinha[5];
                        cli.DataDeNascimento = DateTime.Parse(itensLinha[6]);
                        cli.DataDoCadastro = DateTime.Parse(itensLinha[2]);
                        cli.Nome = itensLinha[4];
                        cli.Observacoes = itensLinha[3];
                        //cli.Sexo = (SexoEnum)itensLinha[7];
                        clientes.Add(cli);
                    }
                    else
                    {
                        var clij = new ClientePessoaJuridica()
                        {
                            ClienteId = Convert.ToInt32(itensLinha[1]),
                            CNPJ = itensLinha[6],
                            DataDaFundacao = DateTime.Parse(itensLinha[6]),
                            DataDoCadastro = DateTime.Parse(itensLinha[2]),
                            InscricaoEstadual = itensLinha[7],
                            NomeFantasia = itensLinha[4],
                            Observacoes = itensLinha[3],
                            RazaoSocial = itensLinha[5]
                        };
                        clientes.Add(clij);
                    }

                }
            }
            return clientes;
        }
        */

        public List<Cliente> CarregarArquivo()
        {
            // Prepara uma lista vazia de clientes para devolver preenchida
            List<Cliente> clientes = new List<Cliente>();

            // chama a classe estatica de leitura e recebe uma lista de strings
            var retorno = FileRepository.Ler("clientes.data");

            if (retorno != null && retorno.Any()) // verifica se houve algum item no retorno
            {
                foreach (var linha in retorno) // percorre os itens do retorno e cria a variavel string linha
                {
                    var itensLinha = linha.Split(";"); //faz um array com o string Linha onde separa cada elemento por um ; 
                    if (itensLinha[0] == "F")
                    {
                        var cli = new ClientePessoaFisica();
                        cli.CarregarDados(itensLinha);
                        clientes.Add(cli);
                    }
                    else
                    {
                        var clij = new ClientePessoaJuridica();
                        clij.CarregarDados(itensLinha);
                        clientes.Add(clij);
                    }
                }
            }
            return clientes;
        }

    }
}
