using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class ClientePessoaJuridica : Cliente
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        public string CNPJ { get; set; }

        public string InscricaoEstadual { get; set; }

        public DateTime DataDaFundacao { get; set; }

        public override string ExibirDados()
        {
            return $"Nomefantasia: {this.NomeFantasia} Cpf: {this.CNPJ} Data da fundação {this.DataDaFundacao.ToString("dd/MM/yyyy")} ";
        }

        public override string PrepararDados()
        {
            return $"J;{base.ClienteId};{base.DataDoCadastro};{base.Observacoes};{this.NomeFantasia};{this.RazaoSocial};{this.CNPJ};{this.DataDaFundacao};{this.InscricaoEstadual}";
        }

        public override void CarregarDados(string[] itensLinha)
        {
            this.ClienteId = Convert.ToInt32(itensLinha[1]);
            this.CNPJ = itensLinha[6];
            this.DataDaFundacao = DateTime.Parse(itensLinha[6]);
            this.DataDoCadastro = DateTime.Parse(itensLinha[2]);
            this.InscricaoEstadual = itensLinha[7];
            this.NomeFantasia = itensLinha[4];
            this.Observacoes = itensLinha[3];
            this.RazaoSocial = itensLinha[5];
        }

        
    }
}
