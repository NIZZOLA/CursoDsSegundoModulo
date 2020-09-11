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

        public override string PrepararDados()
        {
            return $"F;{base.ClienteId};{base.DataDoCadastro};{base.Observacoes};{this.Nome};{this.Cpf};{this.DataDeNascimento};{this.Sexo};";
        }

        public override void CarregarDados(string[] itensLinha)
        {
            this.ClienteId = Convert.ToInt32(itensLinha[1]);
            this.Cpf = itensLinha[5];
            this.DataDeNascimento = DateTime.Parse(itensLinha[6]);
            this.DataDoCadastro = DateTime.Parse(itensLinha[2]);
            this.Nome = itensLinha[4];
            this.Observacoes = itensLinha[3];
            //this.Sexo = (SexoEnum)itensLinha[7];
        }
    }
}
