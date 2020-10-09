using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppExemploInterface
{
    public interface IProdutosService : IServiceBase<ProdutoModel>
    {
        public ProdutoModel ConsultarPorBarcode(string barcode);

    }
}
