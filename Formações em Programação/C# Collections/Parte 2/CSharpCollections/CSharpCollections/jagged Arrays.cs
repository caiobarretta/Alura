using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    partial class Program
    {
        static void JaggedArrays()
        {
            //família 1: Família Flintstones
            //família 2: Família Simpsons
            //família 3: Família Dona Florinda
            // jagged array == array denteado = array serrilhado
            string[][] familias = new string[3][];
            familias[0] = new string[] { "Fred", "Wilma", "Pedrita" };
            familias[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" };
            familias[2] = new string[] { "Florinda", "Kiko" };

            foreach (var familia in familias)
                Console.WriteLine(string.Join(",", familia));
            Console.ReadLine();
        }
    }
}
