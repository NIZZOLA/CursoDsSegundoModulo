using ConsoleOOP.Models;
using ConsoleOOP.Repositoryes;
using ConsoleOOP.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ConsoleOOP
{
    public class ServiceOrchestrator
    {
        private readonly ClienteService _clienteService;
        private readonly ContaBancariaService _contaService;

        private List<Cliente> Clientes { get; set; }
        private List<ContaBancaria> Contas { get; set; }

        public ServiceOrchestrator()
        {
            _clienteService = new ClienteService();
            _contaService = new ContaBancariaService();

            Clientes = _clienteService.CarregarArquivo();
            Contas = new List<ContaBancaria>();

        }

        public void TelaPrincipal()
        {
            int opcoes;
            do
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE CONTAS - TELA PRINCIPAL");
                Console.WriteLine("Opções  \n 1-Cadastrar Cliente \n 2-Cadastrar Conta Bancaria  \n 3-Depositar \n 4-Sacar \n 5-Ver Saldo " +
                    " \n 6-Listar clientes \n 7 - Listar contas  \n 0-Fim");
                opcoes = Convert.ToInt32(Console.ReadLine());
                switch (opcoes)
                {
                    case 1:
                        var cli = _clienteService.CadastrarCliente("");
                        Console.WriteLine( cli.GetType() );
                        Console.WriteLine(cli.ToJson());
                        Console.ReadKey();
                        Clientes.Add(cli);
                        break;
                    case 2:
                        var conta = _contaService.CadastrarConta();
                        Contas.Add(conta);
                        break;
                    case 3:
                        Depositar();
                        break;
                    case 4:
                        Sacar();
                        break;
                    case 5:
                        VerExtrato();
                        break;
                    case 6:
                        ListarClientes();
                        break;
                    case 7:
                        ListarContas();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção incorreta !");
                        break;
                }
            } while (opcoes != 0);
        }

        public void Depositar()
        {
            var contaescolhida = _contaService.BuscarConta(Contas);
            if (contaescolhida != null)
                _contaService.Depositar(contaescolhida);
            else
                Console.WriteLine("Conta não encontrada !");
        }

        public void Sacar()
        {
            var contaescolhida = _contaService.BuscarConta(Contas);
            if (contaescolhida != null)
                _contaService.Sacar(contaescolhida);
            else
                Console.WriteLine("Conta não encontrada !");
        }

        public void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("Listagem dos clientes existentes");

            foreach (var cliente in this.Clientes)
            {
                Console.WriteLine(cliente.ExibirDados() );
            }
            Console.WriteLine("Pressione qualquer tecla !");
            Console.ReadKey();
        }

        public void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("Listagem de contas");

            foreach (var conta in this.Contas)
            {
                Console.WriteLine(conta.ExibirDados()+ " Saldo:" + conta.ConsultarSaldo() );
            }
            Console.WriteLine("Pressione qualquer tecla !");
            Console.ReadKey();
        }

        public void VerExtrato()
        {
            var contaescolhida = _contaService.BuscarConta(Contas);
            if (contaescolhida != null)
            {
                Console.WriteLine("Extrato da conta:" + contaescolhida.ExibirDados());
                foreach (var item in contaescolhida.Movimentacao)
                {
                    Console.WriteLine($"| {item.Data} | {item.Tipo} | {item.Valor} |");
                }
                Console.WriteLine("Saldo atual:" + contaescolhida.ConsultarSaldo());
            }
            else
                Console.WriteLine("Conta não encontrada !");
            
            Console.ReadKey();
        }




    }
}
