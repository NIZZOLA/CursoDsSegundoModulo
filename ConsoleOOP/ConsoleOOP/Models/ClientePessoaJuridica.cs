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

    }
}
