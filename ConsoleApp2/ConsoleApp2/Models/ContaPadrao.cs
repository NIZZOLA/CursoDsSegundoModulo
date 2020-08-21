using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Models
{
    public class ContaPadrao
    {
        public int Agencia { get; set; }
        public int Numero { get; set; }

        public Pessoa Correntista { get; set; }

        private decimal Saldo;

        public decimal VerSaldo()
        {
            return this.Saldo;
        }

        public void Depositar( decimal valor )
        {
            this.Saldo += valor;
        }

        public bool Sacar( decimal valor )
        {
            if (this.Saldo >= valor)
            {
                this.Saldo -= ( valor + CalculaCPMF(valor) );
                return true;
            }

            return false;
        }

        private decimal CalculaCPMF(decimal valor )
        {
            return valor * 0.0001M;
        }

    }
}
