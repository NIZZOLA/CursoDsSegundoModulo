using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

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

        public string ToJson()
        {
            if( this.GetType() == typeof(ClientePessoaFisica)  )
            {
                return JsonSerializer.Serialize((ClientePessoaFisica)this);
            }
            else
            {
                return JsonSerializer.Serialize((ClientePessoaJuridica)this);
            }
        }
    }
}
