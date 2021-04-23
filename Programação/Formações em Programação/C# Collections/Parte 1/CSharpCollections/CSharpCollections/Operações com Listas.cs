using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void Listas()
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

            aulas[0] = "Trabalhando com listas";
            ImprimirFor(aulas);

            Console.WriteLine("A primeira Aula 'Trabalhando' é: {0}", aulas.First(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("A última Aula 'Trabalhando' é: {0}", aulas.Last(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("A primeira Aula 'Conclusão' é: {0}", aulas.FirstOrDefault(aula => aula.Contains("Conclusão")));
            Console.WriteLine("-------------------------------");

            aulas.Reverse();
            ImprimirForEach(aulas);

            aulas.Reverse();
            ImprimirForEach(aulas);

            aulas.RemoveAt(aulas.Count - 1);
            ImprimirForEach(aulas);

            aulas.Add("Conclusão");
            ImprimirForEach(aulas);

            aulas.Sort();
            ImprimirForEach(aulas);

            List<string> copia = aulas.GetRange(aulas.Count - 2, 2);
            ImprimirForEach(copia);

            List<string> clone = new List<string>(aulas);
            ImprimirForEach(clone);

            clone.RemoveRange(clone.Count - 2, clone.Count - 1);
            ImprimirForEach(clone);

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
