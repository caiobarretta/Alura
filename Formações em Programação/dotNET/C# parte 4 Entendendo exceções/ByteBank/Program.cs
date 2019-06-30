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
                ContaCorrente contaCorrente = new ContaCorrente(514, 2543534);
                ContaCorrente contaCorrenteDestino = new ContaCorrente(567, 345345);

                contaCorrenteDestino.Transferir(10000, contaCorrente);

                contaCorrente.Depositar(50);
                Console.WriteLine("O Saldo é: {0}",contaCorrente.Saldo);
                contaCorrente.Sacar(-500);
                Console.WriteLine("O Saldo é: {0}", contaCorrente.Saldo);

            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Saldo);
                Console.WriteLine(ex.ValorSaque);

                Console.WriteLine(ex.StackTrace);

                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argumento com Problema: {0}", ex.ParamName);
                Console.WriteLine("Ocorreu um excessão do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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