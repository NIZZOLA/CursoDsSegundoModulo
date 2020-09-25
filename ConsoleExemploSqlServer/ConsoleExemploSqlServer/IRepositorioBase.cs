using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleExemploSqlServer
{
    public interface IRepositorioBase<T> where T : class
    {
        public bool Inserir(T model);
        public bool Alterar(T model);
        public bool Excluir(int codigo);
        public T Consultar(int codigo);
        public IEnumerable<T> ConsultarTodos();
    }
}
