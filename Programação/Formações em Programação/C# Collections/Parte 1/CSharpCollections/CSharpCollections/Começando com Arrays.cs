using System;

namespace CSharpCollections
{
    partial class Program
    {
        static void Arrays()
        {

            string aulaIntro = "Introdução à coleções";
            string aulaModelando = "Modelando Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";


            //string[] aulas = new string[]
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaModelando,
            //    aulaSets
            //};

            string[] aulas = new string[4];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaModelando;
            aulas[3] = aulaSets;

            Imprimir(aulas);

            Console.WriteLine("-------------------------------");
            aulaIntro = "Trabalhando com Arrays";
            ImprimirFor(aulas);

            Console.WriteLine("-------------------------------");
            aulas[0] = "Trabalhando com Arrays";
            ImprimirForEach(aulas);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Aula Modelando ocorre pela primeira vez no índice: {Array.IndexOf(aulas, aulaModelando)}");
            Console.WriteLine($"Aula Modelando ocorre pela última vez no índice: {Array.LastIndexOf(aulas, aulaModelando)}");

            Console.WriteLine("-------------------------------");
            Array.Reverse(aulas);
            Imprimir(aulas);

            Console.WriteLine("-------------------------------");
            Array.Reverse(aulas);
            Imprimir(aulas);

            Console.WriteLine("-------------------------------");
            Array.Resize(ref aulas, 3);
            ImprimirForEach(aulas);

            Console.WriteLine("-------------------------------");
            Array.Resize(ref aulas, 4);
            ImprimirForEach(aulas);

            Console.WriteLine("-------------------------------");
            aulas[aulas.Length - 1] = "Conclusão";
            ImprimirForEach(aulas);

            Console.WriteLine("-------------------------------");
            Array.Sort(aulas);
            ImprimirFor(aulas);

            Console.WriteLine("-------------------------------");
            string[] copia = new string[2];
            Array.Copy(aulas, 1, copia, 0, 2);
            ImprimirForEach(copia);

            Console.WriteLine("-------------------------------");
            string[] clone = aulas.Clone() as string[];
            ImprimirFor(clone);

            Console.WriteLine("-------------------------------");
            Array.Clear(clone, 1, clone.Length - 1);
            ImprimirForEach(clone);

            Console.ReadLine();
        }

        static void Imprimir(string[] aulas)
        {
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[1]);
            Console.WriteLine(aulas[2]);
            Console.WriteLine(aulas[3]);
        }

        static void ImprimirFor(string[] aulas)
        {
            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }
        }

        static void ImprimirForEach(string[] aulas)
        {
            foreach (var aula in aulas)
                Console.WriteLine(aula);
        }
    }
}
