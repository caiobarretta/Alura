using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string[,] resultados = new string[4, 3]
            {
                { "Alemanha", "Espanha","Itália" },
                { "Argentina", "Holanda", "França" },
                { "Holanda", "Alemanha", "Alemanha" },
                { "Brasil", "Uruguai", "Portugal" }
            };
            ImprimirFor(resultados);


            Console.ReadLine();
        }

        static void ImprimirForEach(string[,] collection)
        {
            Console.WriteLine("-------------------------------");
            foreach (var item in collection)
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------");

        }

        static void ImprimirFor(string[,] collection)
        {
            Console.WriteLine(" -------------------------------------");
            Console.Write("| ");
            for (int copa = 0; copa <= collection.GetUpperBound(1); copa++)
            {
                int ano = 2014 - (copa * 4);
                Console.Write(ano.ToString().PadRight(12));
            }
            Console.WriteLine("|");

            for (int posicao = 0; posicao <= collection.GetUpperBound(0); posicao++)
            {
                Console.Write("| ");
                for (int copa = 0; copa <= collection.GetUpperBound(1); copa++)
                    Console.Write(collection[posicao, copa].PadRight(12));
                Console.WriteLine("|");
            }
            Console.WriteLine(" -------------------------------------");
        }
    }
}
