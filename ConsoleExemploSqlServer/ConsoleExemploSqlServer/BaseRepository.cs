using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleExemploSqlServer
{
    public class BaseRepository
    {
        private readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected bool ExecuteNonQuery( string cmdSql )
        {
            var resposta = false;
            
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(cmdSql, con);
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
    }
}
