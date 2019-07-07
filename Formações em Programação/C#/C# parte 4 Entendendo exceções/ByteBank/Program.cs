using System;
using System.Collections.Generic;
using System.IO;
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
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no método main");
            }

            Console.WriteLine("Execução Finalizada, clique enter para sair");
            Console.ReadLine();
        }
        public static void CarregarContas()
        {

            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {

                leitor.LerProximaLinha();
            }

            // ----------------------------------------------------------------------------
            //LeitorDeArquivo leitor = null;
            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //}
            //finally
            //{
            //    Console.WriteLine("Executando o Finally");
            //    if(leitor != null)
            //        leitor.Fechar();
            //}

        }
        public static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(1234, 12312312);
                ContaCorrente conta2 = new ContaCorrente(1234, 12312312);
                
                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
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