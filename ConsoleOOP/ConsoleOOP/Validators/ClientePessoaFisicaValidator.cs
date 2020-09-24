using ConsoleOOP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Validators
{
    public class ClientePessoaFisicaValidator
    {
        public List<string> IsValid( ClientePessoaFisica pessoa)
        {
            List<string> erros = new List<string>();
            if (pessoa.Nome.Length > 50)
            {
                erros.Add("O nome deve ter 50 caracteres");
            }

            if (pessoa.Cpf.Length > 18)
            {
                erros.Add("O cpf deve ter 18 caracteres");
            }
            
            return erros;
        }

    }
}
