using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppExemploInterface
{
    public interface IServiceBase<T> where T : class
    {
        public bool Incluir(T model);

        public bool Alterar(T model);

        public bool Excluir(T model);

        public T Consultar(int id);

        public ICollection<T> ConsultarTodos();

    }
}
