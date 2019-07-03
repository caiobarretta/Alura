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

            // pagina?argumentos
            // 012345678

            string url = "paginas?argumentos";

            Console.WriteLine(url);
            var argumentos = url.Substring(8);
            Console.WriteLine(argumentos);

            Console.ReadLine();
        }
    }
}
