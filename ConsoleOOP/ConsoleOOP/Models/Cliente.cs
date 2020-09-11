using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public DateTime DataDoCadastro { get; set; }

        public string Observacoes { get; set; }

        public virtual string ExibirDados()
        {
            return "";
        }

        public virtual string PrepararDados()
        {
            return "";
        }

        public virtual void CarregarDados(string[] itensLinha)
        {

        }
    }
}
