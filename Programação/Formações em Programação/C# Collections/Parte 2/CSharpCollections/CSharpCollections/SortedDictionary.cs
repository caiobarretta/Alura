using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    partial class Program
    {
        static void SortedDictionary()
        {
            IDictionary<string, Aluno> sorted = new SortedDictionary<string, Aluno>();
            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));
            Imprimir(sorted);

            Console.ReadLine();
        }
    }
}
