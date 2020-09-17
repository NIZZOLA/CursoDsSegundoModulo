using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppJsonConverter
{
    public class Cliente
    {
        public Cliente()
        {
            Enderecos = new List<ClienteEndereco>();
        }
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public bool Ativo { get; set; }

        public List<ClienteEndereco> Enderecos { get; set; }
    }
}
