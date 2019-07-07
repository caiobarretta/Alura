using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var aulas = new List<Aula>()
            {
                new Aula("Introdução à coleções", 20),
                new Aula("Modelando Classe Aula", 18),
                new Aula("Trabalhando com conjuntos", 16)
            };

            Imprimir(aulas);
            ImprimirFor(aulas);
            ImprimirForEach(aulas);
            ImprimirListForEach(aulas);

            aulas.Sort();
            ImprimirListForEach(aulas);

            aulas.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo));
            ImprimirListForEach(aulas);

            Console.ReadLine();
        }

        static void Imprimir(List<Aula> aulas)
        {
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[1]);
            Console.WriteLine(aulas[2]);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirFor(List<Aula> aulas)
        {
            for (int i = 0; i < aulas.Count; i++)
                Console.WriteLine(aulas[i]);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirForEach(List<Aula> aulas)
        {
            foreach (var aula in aulas)
                Console.WriteLine(aula);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirListForEach(List<Aula> aulas)
        {
            aulas.ForEach(aula => { Console.WriteLine(aula); });
            Console.WriteLine("-------------------------------");
        }
    }
}
