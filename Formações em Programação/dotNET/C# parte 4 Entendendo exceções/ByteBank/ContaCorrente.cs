using System;

namespace ByteBank
{
    public class ContaCorrente
    {

        public static double TaxaOperacao { get; private set; }
        public Cliente Titular { get; set; }

        public static int TotalDeContasCriadas { get; private set; }
        public int Agencia { get; }

        public int Numero { get; }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            private set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
                throw new ArgumentException("O Argumento agência deve ser maior que zero.", nameof(agencia));

            if (numero <= 0)
                throw new ArgumentException("O Argumento número deve ser maior que zero.", nameof(numero));

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para saque.", nameof(valor));

            if (_saldo < valor)
                throw new SaldoInsuficienteException(_saldo, valor);

            _saldo -= valor;
        }

        public void Depositar(double valor) => _saldo += valor;


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));

            Sacar(valor);
            contaDestino.Depositar(valor);
        }
    }
}
