using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class Funcionario : ClientePessoaFisica
    {
        public string Matricula { get; set; }
        public DateTime DataDacontratacao { get; set; }

        public Funcionario SuperiorImediato { get; set; }
    }
}
