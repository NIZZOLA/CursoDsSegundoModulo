using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class ContaBancaria
    {
        public ContaBancaria()
        {
            Movimentacao = new List<MovimentacaoDaConta>();
        }

        public int ContaBancariaId { get; set; }

        public int Agencia { get; set; }
        public int Conta { get; set; }

        public Cliente Titular1 { get; set; }
        public Cliente Titular2 { get; set; }

        protected decimal Saldo;

        public DateTime DataDaAbertura { get; set; }

        public decimal ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void Depositar( decimal valor )
        {
            this.Saldo += valor;

            var movimentacao = new MovimentacaoDaConta() { Data = DateTime.Now, Tipo = TipoDeMovimentacaoEnum.Credito, Valor = valor };
            this.Movimentacao.Add(movimentacao);
        }

        public virtual bool Sacar( decimal valor )
        {
            this.Saldo -= valor;
            var movimentacao = new MovimentacaoDaConta() { Data = DateTime.Now, Tipo = TipoDeMovimentacaoEnum.Debito, Valor = valor };
            this.Movimentacao.Add(movimentacao);
            return true;
        }

        public List<MovimentacaoDaConta> Movimentacao { get; }

    }
}
