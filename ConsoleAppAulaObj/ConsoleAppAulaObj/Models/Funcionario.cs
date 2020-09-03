using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAulaObj.Models
{
    public class Funcionario : Pessoa
    {
        public DateTime DataDaContratacao { get; set; }
        public string CargoAtual { get; set; }

        public DateTime DataDaDemissao { get; set; }



    }
}
