using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppExemploInterface
{
    public class ProdutoService : IProdutosService
    {
        public bool Alterar(ProdutoModel model)
        {
            throw new NotImplementedException();
        }

        public ProdutoModel Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public ProdutoModel ConsultarPorBarcode(string barcode)
        {
            throw new NotImplementedException();
        }

        public ICollection<ProdutoModel> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Excluir(ProdutoModel model)
        {
            throw new NotImplementedException();
        }

        public bool Incluir(ProdutoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
