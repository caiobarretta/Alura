using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void OperadoresDeConjuntosLINQ(string[] args)
        {
            string[] seq1 = { "janeiro", "fevereiro", "março" };
            string[] seq2 = { "fevereiro", "MARÇO", "abril" };

            Console.WriteLine("Concatenando duas sequências");
            foreach (var item in seq1.Concat(seq2))
                Console.WriteLine(item);

            Console.Clear();
            Console.WriteLine("União de duas sequências");
            foreach (var item in seq1.Union(seq2))
                Console.WriteLine(item);

            Console.Clear();
            Console.WriteLine("União de duas sequências com comparador");
            foreach (var item in seq1.Union(seq2, StringComparer.CurrentCultureIgnoreCase))
                Console.WriteLine(item);

            Console.Clear();
            Console.WriteLine("Interseção de duas sequências");
            foreach (var item in seq1.Intersect(seq2))
                Console.WriteLine(item);

            Console.Clear();
            Console.WriteLine("Exceto: elementos de seq1 que não estão na seq2");
            foreach (var item in seq1.Except(seq2))
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
