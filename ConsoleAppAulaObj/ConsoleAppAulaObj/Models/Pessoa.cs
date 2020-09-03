using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppAulaObj.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            EnderecoDeentrega = new Endereco();
            EnderecoDeCobranca = new Endereco();
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }

        public char Sexo { get; set; }

        public int Idade()
        {
            return DateTime.Now.Subtract(this.Nascimento).Hours / 365;
        }


        public Endereco EnderecoDeentrega { get; set; }

        public Endereco EnderecoDeCobranca { get; set; }


        private int CalcularIdade()
        {
            var dias = DateTime.Today.Subtract(this.Nascimento).TotalDays;
            return Convert.ToInt32(dias / 365);
        }

        public bool ValidarCadastro()
        {
            if (Nascimento > DateTime.Today)
                return false;

            if (Nome.Length > 5)
                return false;

            return true;
        }

    }
}
