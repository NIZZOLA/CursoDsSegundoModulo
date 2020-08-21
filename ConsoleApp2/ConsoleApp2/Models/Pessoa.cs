using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp2.Models
{
    public class Pessoa
    {
        [Key]
        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

    }
}
