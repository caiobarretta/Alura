using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string aulaIntro = "Introdução à coleções";
            string aulaModelando = "Modelando Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";

            //List<string> aulas = new List<string>()
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};

            List<string> aulas = new List<string>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);
            ImprimirListForEach(aulas);

            Console.WriteLine($"A primeira Aula é: {aulas[0]}");
            Console.WriteLine($"A primeira Aula é: {aulas.First()}");
            Console.WriteLine($"A última Aula é: {aulas[aulas.Count - 1]}");
            Console.WriteLine($"A última Aula é: {aulas.Last()}");
            Console.WriteLine("-------------------------------");

            Console.ReadLine();
        }

        static void Imprimir(List<string> aulas)
        {
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[1]);
            Console.WriteLine(aulas[2]);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirFor(List<string> aulas)
        {
            for (int i = 0; i < aulas.Count; i++)
                Console.WriteLine(aulas[i]);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirForEach(List<string> aulas)
        {
            foreach (var aula in aulas)
                Console.WriteLine(aula);
            Console.WriteLine("-------------------------------");
        }

        static void ImprimirListForEach(List<string> aulas)
        {
            aulas.ForEach(aula => { Console.WriteLine(aula); });
            Console.WriteLine("-------------------------------");
        }

    }
}
