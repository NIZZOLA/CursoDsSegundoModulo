using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOOP.Models
{
    public class ContaPoupanca : ContaBancaria
    {
        public int DiaDeAniversario { get; set; }

        public override bool Sacar(decimal valor)
        {
            if (base.Saldo >= valor)
            {
                /*   através da herança podemos utilizar ainda a classe pai para fazer a transação já que o código é o mesmo
                base.Saldo -= valor;
                var movimentacao = new MovimentacaoDaConta() { Data = DateTime.Now, Tipo = TipoDeMovimentacaoEnum.Debito, Valor = valor };
                this.Movimentacao.Add(movimentacao);
                 */
                return base.Sacar(valor); ;
            }
            return false;

        }
    }
}
