using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAulaObj.Models
{
    public class Empresa
    {
        public Empresa()
        {
            Enderecos = new List<Endereco>();
            Funcionarios = new List<Funcionario>();
        }

        public string Nome { get; set; }

        
        public List<Endereco> Enderecos { get; set; }

        public List<Funcionario> Funcionarios { get; set; }

    }
}
