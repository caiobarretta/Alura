using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ContaCorrente conta1 = new ContaCorrente(1234, 12312312);
                ContaCorrente conta2 = new ContaCorrente(1234, 12312312);

                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch(OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("Execução Finalizada, clique enter para sair");
            Console.ReadLine();
        }
        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Metodo() => TestaDivisao(0);

        private static void TestaDivisao(int divisor)
        {
            
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);

        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Exceção com número:{0} e divisor: {1}", numero, divisor);
                throw;
            }
        }
    }
}