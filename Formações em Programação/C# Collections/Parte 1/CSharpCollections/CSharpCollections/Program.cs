using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var csharpColecoes = new Curso("C# Collections", "Marcelo Oliveira");
            csharpColecoes.AdicionarAula(new Aula("Trabalhando com Listas", 21));
            ImprimirForEach(csharpColecoes.Aulas);

            Console.ReadLine();
        }

        static void Imprimir(IList<Aula> aulas)
        {
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[1]);
            Console.WriteLine(aulas[2]);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirFor(IList<Aula> aulas)
        {
            for (int i = 0; i < aulas.Count; i++)
                Console.WriteLine(aulas[i]);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirForEach(IList<Aula> aulas)
        {
            foreach (var aula in aulas)
                Console.WriteLine(aula);
            Console.WriteLine("-------------------------------");
        }

    }
}
