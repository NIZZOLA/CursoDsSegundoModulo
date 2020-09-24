using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleExemploSqlServer
{
    public class ClienteRepository
    {
        private readonly string _connectionString;
        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Inserir( ClienteModel cli )
        {
            var resposta = false;
            string comandoSql = $"INSERT INTO CLIENTES (codigo, nome, email, telefone ) values " +
                  $"( {cli.Codigo}, '{cli.Nome}', '{cli.Email}', '{cli.Telefone}' )";


            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(comandoSql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                var i = cmd.ExecuteNonQuery();
                if (i > 0)
                    resposta = true;
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

            return resposta;
        }


        public bool Atualizar( ClienteModel cli )
        {

            return false;
        }

        public bool Excluir( int codigo )
        {
            return false;
        }

        public ClienteModel Consultar( int codigo )
        {
            ClienteModel cli = new ClienteModel();

            string sql = "SELECT * FROM CLIENTES where codigo=" + codigo;

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cli.Codigo = Convert.ToInt32(reader[0].ToString());
                    cli.Nome = reader[1].ToString();
                    cli.Email = reader[2].ToString();
                    cli.Telefone = reader[3].ToString();
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

            return cli;
        }

        public List<ClienteModel> Consultar()
        {
            var clientes = new List<ClienteModel>();
            string sql = "SELECT * FROM CLIENTES order by NOME";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var cli = new ClienteModel();
                    cli.Codigo = Convert.ToInt32(reader[0].ToString());
                    cli.Nome = reader[1].ToString();
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

            return clientes;
        }


    }
}
