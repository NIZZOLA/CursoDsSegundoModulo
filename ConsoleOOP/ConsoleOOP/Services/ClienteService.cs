using ConsoleOOP.Models;
using ConsoleOOP.Repositoryes;
using ConsoleOOP.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var validador = new ClientePessoaFisicaValidator();
            var cli = new ClientePessoaFisica();
            List<string> validationResult;

            do
            {

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

                validationResult = validador.IsValid(cli);
                if( validationResult.Any() )
                {
                    Console.WriteLine("Houveram erros de validação!");
                    foreach (var item in validationResult)
                    {
                        Console.WriteLine(item);
                    }
                }

            } while (validationResult.Any());

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

        public List<Cliente> CarregarArquivoTexto()
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

        public List<Cliente> CarregarJson()
        {
            var pessoaFisicaJsonTexto = FileRepository.LerJson("clientesPf.json");
            var pessoasFisicas = JsonSerializer.Deserialize<List<ClientePessoaFisica>>(pessoaFisicaJsonTexto);

            var pessoaJuridicaJsonTexto = FileRepository.LerJson("clientesPj.json");
            var pessoasJuridicas = JsonSerializer.Deserialize<List<ClientePessoaJuridica>>(pessoaJuridicaJsonTexto);

            List<Cliente> retorno = new List<Cliente>();
            retorno.AddRange(pessoasJuridicas);
            retorno.AddRange(pessoasFisicas);

            return retorno;
        }

        public void GravarJson( List<Cliente> clientes )
        {
            List<ClientePessoaFisica> listaFisica = new List<ClientePessoaFisica>();
            List<ClientePessoaJuridica> listaJuridica = new List<ClientePessoaJuridica>();

            foreach (var cliente in clientes)
            {
                if (cliente.GetType() == typeof(ClientePessoaFisica))
                {
                    listaFisica.Add((ClientePessoaFisica)cliente);
                }
                else
                {
                    listaJuridica.Add((ClientePessoaJuridica)cliente);
                }
            }

            var clientesFisicaJson = JsonSerializer.Serialize(listaFisica);
            FileRepository.Gravar("clientesPf.json", clientesFisicaJson, false);

            FileRepository.Gravar("clientesPj.json", JsonSerializer.Serialize(listaJuridica), false);
        }

    }
}
