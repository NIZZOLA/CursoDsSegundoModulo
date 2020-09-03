using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class ClientePessoaFisica : Cliente
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataDeNascimento { get; set; }
    
        public SexoEnum Sexo { get; set; }
    }
}
