using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    partial class Program
    {
        static void SortedSet()
        {
            //Conjunto de alunos
            ISet<string> alunos = new SortedSet<string>(new ComparadorMinusculo())
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Pricisla Stuani"
            };
            Imprimir(alunos);

            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            alunos.Add("Fabio Gushiken");
            alunos.Add("FABIO GUSHIKEN");
            Imprimir(alunos);

            //Este conjunto é subconjunto do outro? IsSubsetof.
            ISet<string> alunosSubsetTrue = new HashSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Pricisla Stuani",
                "Rafael Rollo",
                "Fabio Gushiken",
                "Caio Augusto"
            };
            Console.WriteLine("Este conjunto é subconjunto do outro? {0}", alunos.IsSubsetOf(alunosSubsetTrue));

            ISet<string> alunosSubsetFalse = new HashSet<string>()
            {
                "Caio Augusto",
                "Kiara das Neves",
                "Daniela Pereira"
            };
            Console.WriteLine("Este conjunto é subconjunto do outro? {0}", alunos.IsSubsetOf(alunosSubsetFalse));
            Console.WriteLine("-------------------------------");

            //Este conjunto é superconjunto do outro? IsSupersetof.
            ISet<string> alunosSupersetTrue = new HashSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian"
            };
            Console.WriteLine("Este conjunto é superconjunto do outro? {0}", alunos.IsSupersetOf(alunosSupersetTrue));

            ISet<string> alunosSupersetFalse = new HashSet<string>()
            {
                "Caio Augusto",
                "Kiara das Neves",
                "Daniela Pereira"
            };
            Console.WriteLine("Este conjunto é superconjunto do outro? {0}", alunos.IsSupersetOf(alunosSupersetFalse));
            Console.WriteLine("-------------------------------");

            //Os conjuntos contêm os mesmos elementos? SetEquals.
            ISet<string> alunosSetEqualsTrue = new HashSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Pricisla Stuani",
                "Rafael Rollo",
                "Fabio Gushiken"
            };
            Console.WriteLine("Os conjuntos contêm os mesmos elementos? {0}", alunos.SetEquals(alunosSetEqualsTrue));

            ISet<string> alunosSetEqualsFalse = new HashSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Pricisla Stuani",
                "Rafael Rollo",
                "Fabio Gushiken",
                "Caio Augusto"
            };
            Console.WriteLine("Os conjuntos contêm os mesmos elementos? {0}", alunos.SetEquals(alunosSetEqualsFalse));
            Console.WriteLine("-------------------------------");

            ISet<string> alunosExceptWith = new HashSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak"
            };
            //Subtrair os elementos da outra coleção que também estão neste conjunto. ExceptWith.
            Console.WriteLine("Subtrair os elementos da outra coleção que também estão neste conjunto: ");
            alunos.ExceptWith(alunosExceptWith);
            Imprimir(alunos);

            ISet<string> alunosIntersectWith = new HashSet<string>()
            {
                "Rafael Nercessian",
                "Pricisla Stuani"
            };
            //Intersecção dos conjuntos - IntersectWith
            Console.WriteLine("Intersecção dos conjuntos: ");
            alunos.IntersectWith(alunosIntersectWith);
            Imprimir(alunos);

            //Somente em um ou outro conjunto - SymmetricExceptWith
            ISet<string> alunosSymmetricExceptWith = new HashSet<string>()
            {
                "Rafael Nercessian"
            };
            Console.WriteLine("Somente em um ou outro conjunto: ");
            alunos.SymmetricExceptWith(alunosSymmetricExceptWith);
            Imprimir(alunos);

            //União de conjuntos - UnionWith
            ISet<string> alunosUnionWith = new HashSet<string>()
            {
                "Caio Augusto",
                "Kiara das Neves",
                "Daniela Pereira"
            };
            ISet<string> alunos2 = new SortedSet<string>()
            {
                "Vanessa Tonini",
                "Ana Losnak",
                "Rafael Nercessian",
                "Pricisla Stuani"
            };
            Console.WriteLine("União de conjuntos: ");
            alunos2.UnionWith(alunosUnionWith);
            Imprimir(alunos2);

            Console.ReadLine();
        }

        static void Imprimir(ISet<string> collection)
        {
            Console.WriteLine("-------------------------------");
            foreach (var item in collection)
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------");
        }
    }
}
