using System;

namespace CSharpCollections
{
    class Program
    {
        static void Main(string[] args)
        {

            string aulaIntro = "Introdução à coleções";
            string aulaModelando = "Modelando Classe Aula";
            string aulaSets = "Trabalhando com conjuntos";


            //string[] aulas = new string[]
            //{
            //    aulaIntro,
            //    aulaModelando,
            //    aulaSets
            //};

            string[] aulas = new string[3];
            aulas[0] = aulaIntro;
            aulas[1] = aulaModelando;
            aulas[2] = aulaSets;

            Imprimir(aulas);

            Console.WriteLine("-------------------------------");
            aulaIntro = "Trabalhando com Arrays";

            Imprimir(aulas);

            Console.WriteLine("-------------------------------");
            aulas[0] = "Trabalhando com Arrays";

            Imprimir(aulas);

            Console.ReadLine();
        }

        private static void Imprimir(string[] aulas)
        {
            Console.WriteLine(aulas[0]);
            Console.WriteLine(aulas[1]);
            Console.WriteLine(aulas[2]);
        }

        private static void ImprimirForeach(string[] aulas)
        {
            foreach (var aula in aulas)
                Console.WriteLine(aula);
        }

        private static void ImprimirFor(string[] aulas)
        {
            for (int i = 0; i < aulas.Length; i++)
            {
                Console.WriteLine(aulas[i]);
            }
        }
    }
}
