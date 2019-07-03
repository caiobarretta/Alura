using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime DataFimPagamento = new DateTime(2020, 08, 17);
            DateTime DataCorrente = DateTime.Now;

            TimeSpan diferenca = DataFimPagamento - DataCorrente;


            Console.WriteLine("Vencimento em :{0} ", TimeSpanHumanizeExtensions.Humanize(diferenca));

            Console.ReadLine();
        }
    }
}
