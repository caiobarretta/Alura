using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_ByteBank
{
    public class ContaCorrente
    {
        public Cliente titular;
        public int agencia;
        public int numero;
        private double saldo = 100;


        public double ObterSaldo() => saldo;

        public void DefinirSaldo(double saldo)
        {
            if (saldo < 0)
                return;
            else
                this.saldo = saldo;
        }

        public bool Sacar(double valor)
        {
            if (saldo < valor)
                return false;

            saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (saldo < valor)
                return false;

            saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }

    }
}