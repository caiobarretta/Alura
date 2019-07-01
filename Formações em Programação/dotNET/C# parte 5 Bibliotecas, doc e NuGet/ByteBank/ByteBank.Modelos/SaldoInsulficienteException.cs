using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {

        public double Saldo { get; }
        public double ValorSaque { get; }
        public SaldoInsuficienteException()
        {

        }

        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

        public SaldoInsuficienteException(double saldo, double valorSaque) : 
            this(string.Format("saldo insuficiente para o valor de: {0}", valorSaque))
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }
        public SaldoInsuficienteException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
