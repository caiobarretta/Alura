using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var meses = new string[]
            {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Dezembro", "Outubro", "Novembro"
            };

            foreach (var mes in meses)
            {
                meses[0] = meses[0].ToUpper();
                Console.WriteLine(mes);
            }

            Console.ReadLine();
        }
    }
}
