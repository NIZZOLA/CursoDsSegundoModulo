using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class MovimentacaoDaConta
    {
        public DateTime Data { get; set; }
        public TipoDeMovimentacaoEnum Tipo { get; set; }
        public decimal Valor { get; set; }

    }
}
