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

        public override string ExibirDados()
        {
            return $"Nome: {this.Nome} Cpf: {this.Cpf} Nascimento {this.DataDeNascimento.ToString("dd/MM/yyyy")} Sexo: {this.Sexo} ";
        }
    }
}
