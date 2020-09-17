using System;
using System.Text.Json;

namespace ConsoleAppJsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aprendendo trabalhar com Json");

            var cli1 = new Cliente()
            {
                ClienteId = 1,
                Ativo = true,
                Nome = "MARCIO R NIZZOLA",
                Cpf = "111.222.333-44",
                DataDeNascimento = DateTime.Parse("01/01/2000")
            };

            cli1.Enderecos.Add(new ClienteEndereco() { Bairro = "Centro", Cep = "13.300-210", Cidade = "ITU", Estado = "SP", ClienteEnderecoId = 1, Numero = 146, Rua = "MAESTRO JOSE VITORIO" });
            cli1.Enderecos.Add(new ClienteEndereco() { Bairro = "Rancho Grande", Cep = "13.300-400", Cidade = "ITU", Estado = "SP", ClienteEnderecoId = 1, Numero = 410, Rua = "AVENIDA BARATA RIBEIRO" });

            // transformar em Json
            var jsonString = JsonSerializer.Serialize(cli1);

            string jsonString2 = "{ \"ClienteId\": 2, \"Nome\": \"PEDRO HENRIQUE GABRIEL DIAS CORREIA\",\"Cpf\": \"444.888.333-44\",\"DataDeNascimento\": \"1995-06-01T00:00:00\",	\"Ativo\": false  }";

            var cli2 = JsonSerializer.Deserialize<Cliente>(jsonString2);



            Console.WriteLine(jsonString);


            Console.ReadKey();


        }
    }
}
