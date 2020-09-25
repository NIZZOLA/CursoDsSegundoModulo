using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleExemploSqlServer
{
    public class ClienteRepository : BaseRepository
    {
        private readonly string _connectionString;
        public ClienteRepository(string connectionString) : base( connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Inserir( ClienteModel cli )
        {
            string comandoSql = $"INSERT INTO CLIENTES (codigo, nome, email, telefone ) values " +
                  $"( {cli.Codigo}, '{cli.Nome}', '{cli.Email}', '{cli.Telefone}' )";

            return base.ExecuteNonQuery(comandoSql);
        }

        public bool Alterar( ClienteModel cli )
        {
            string comandoSql = $"UPDATE CLIENTES SET nome='{cli.Nome}', email='{cli.Email}', telefone='{cli.Telefone}' " +
                 $"WHERE CODIGO={cli.Codigo}";

            return base.ExecuteNonQuery(comandoSql);
        }

        public bool Excluir( int codigo )
        {
            var comandoSql = "DELETE FROM CLIENTES WHERE CODIGO=" + codigo;

            return base.ExecuteNonQuery(comandoSql);
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
                    cli.Nome = reader["nome"].ToString();
                    cli.Email = reader["email"].ToString();
                    cli.Telefone = reader["telefone"].ToString();
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

        public IEnumerable<ClienteModel> ConsultarTodos()
        {
            string sql = "SELECT * FROM CLIENTES order by NOME";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var clilist = con.Query<ClienteModel>(sql);
                return clilist;
            }

           return null;
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
