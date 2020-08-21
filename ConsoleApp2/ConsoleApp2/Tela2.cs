using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Tela2
    {
        public void MontaTela(Produto prod)
        {
            Console.Write($"\nCodigo: {prod.Codigo} \nDescrição: {prod.Descricao} \nUnidade de Medida: {prod.UnidadeDeMedida} "
                        + $"\nPreço: {prod.ValorDeVenda()} \n");
        }
    }
}
