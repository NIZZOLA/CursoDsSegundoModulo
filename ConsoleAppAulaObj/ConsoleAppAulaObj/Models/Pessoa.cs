using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAulaObj.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public char Sexo { get; set; }

    }
}
