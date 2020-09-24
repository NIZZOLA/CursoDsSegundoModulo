using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace ConsoleExemploSqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=localhost,1433;Initial Catalog=ETEC2020;Persist Security Info=True;User ID=sa;Password=#20#";

            //Inclusao(connectionString);
            //Listagem(connectionString);

            ClienteRepository cliRepo = new ClienteRepository(connectionString);

            ClienteModel cli = new ClienteModel()
            {
                Codigo = 2,
                Nome = "KELVIN CORREIA DO NASCIMENTO",
                Email = "kelvin.nascimento@etec.sp.gov.br",
                Telefone = "(11)99999-9999"

            };

            if (cliRepo.Inserir(cli))
                Console.WriteLine("Sucesso na inclusão!");
            else
                Console.WriteLine("Erro !");


        }

        static void Listagem(string connectionString)
        {
            string sql = "SELECT * FROM CLIENTES order by NOME";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                List<ClienteModel> clientes = new List<ClienteModel>();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cli = new ClienteModel();
                    cli.Codigo = Convert.ToInt32(reader[0].ToString());
                    cli.Nome = reader[1].ToString();
                    Console.WriteLine(cli.Nome);
                    cli.Email = reader[2].ToString();
                    cli.Telefone = reader[3].ToString();

                    clientes.Add(cli);
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro " + erro.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        static void Inclusao( string connectionString)
        {

            ClienteModel cli = new ClienteModel()
            {
                Codigo = 2,
                Nome = "Rodrigo Henrique Paulino",
                Email = "rodrigo.paulino@etec.sp.gov.br",
                Telefone = "(11)99999-9999"

            };

            string comandoSql = $"INSERT INTO CLIENTES (codigo, nome, email, telefone ) values " +
                  $"( {cli.Codigo}, '{cli.Nome}', '{cli.Email}', '{cli.Telefone}' )";


            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(comandoSql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                var i = cmd.ExecuteNonQuery();
                if (i > 0)
                    Console.WriteLine("Registro inserido com sucesso !");
            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro " + erro.ToString());
                throw;
            }
            finally
            {
                con.Close();
            }


        }
    }
}
