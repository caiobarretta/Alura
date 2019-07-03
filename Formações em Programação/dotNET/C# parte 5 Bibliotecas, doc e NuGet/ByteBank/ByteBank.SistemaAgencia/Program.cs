using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime DataFimPagamento = new DateTime(2020, 08, 17);
            DateTime DataCorrente = DateTime.Now;

            TimeSpan diferenca = DataFimPagamento - DataCorrente;


            Console.WriteLine("Vencimento em :{0}", GetIntervaloDeTempoLegivel(diferenca));

            Console.ReadLine();
        }

        static string GetIntervaloDeTempoLegivel(TimeSpan timeSpan)
        {
            if (timeSpan.Days > 30)
            {
                int quantidadeMenses = timeSpan.Days / 30;
                return string.Format("{0} meses", quantidadeMenses);
            }
            return string.Format("{0} dias", timeSpan.Days);
        }
    }
}
