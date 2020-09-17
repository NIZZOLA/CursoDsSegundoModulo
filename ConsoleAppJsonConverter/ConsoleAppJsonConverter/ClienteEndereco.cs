using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppJsonConverter
{
    public class ClienteEndereco
    {
        public int ClienteEnderecoId { get; set; }

        public string Rua { get; set; }

        public int Numero { get; set; }
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }
    }
}
