using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class Produto
    {
        public Produto()
        {

        }

        public Produto(int codigo, string descricao, string unmed , decimal vlcusto, decimal margem)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.UnidadeDeMedida = unmed;
            this.ValorDeCusto = vlcusto;
            this.MargemDeLucro = margem;
        }

        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public string UnidadeDeMedida { get; set; }

        private decimal ValorDeCusto { get; set; }

        private decimal MargemDeLucro { get; set; }

        public decimal ValorDeVenda()
        {
            return ValorDeCusto + (ValorDeCusto * MargemDeLucro / 100);
        }


    }
}
