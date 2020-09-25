using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleExemploSqlServer
{
    public class PessoaRepository : BaseRepository,  IRepositorioBase<PessoaModel>
    {
        public PessoaRepository(string sqlConn) : base(sqlConn)
        {

        }


        public bool Alterar(PessoaModel model)
        {
            string sqlcmd = "";
            return base.ExecuteNonQuery(sqlcmd);
        }

        public PessoaModel Consultar(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PessoaModel> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int codigo)
        {
            throw new NotImplementedException();
        }

        public bool Inserir(PessoaModel model)
        {
            throw new NotImplementedException();
        }
    }
}
