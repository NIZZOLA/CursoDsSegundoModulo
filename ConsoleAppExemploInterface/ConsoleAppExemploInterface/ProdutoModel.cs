using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppExemploInterface
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string Barcode { get; set; }
    }
}
