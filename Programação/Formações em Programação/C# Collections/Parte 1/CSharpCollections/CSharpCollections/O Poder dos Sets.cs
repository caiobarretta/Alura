using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void IntroducaoSets()
        {
            //SETS = Conjuntos

            //Duas propriedades do Set
            //1. não permite duplicidade
            //2. os elementos não são mantidos em ordem específica

            ISet<string> alunos = new HashSet<string>();
            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");
            Console.WriteLine(string.Join(Environment.NewLine, alunos));
            Console.WriteLine("-------------------------------");

            alunos.Add("Priscila Stuani");
            alunos.Add("Rafael Rollo");
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(Environment.NewLine, alunos));
            Console.WriteLine("-------------------------------");

            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Oliveira");
            Console.WriteLine(string.Join(Environment.NewLine, alunos));
            Console.WriteLine("-------------------------------");

            //adicionando elemento duplicado
            alunos.Add("Fabio Gushiken");
            Console.WriteLine(string.Join(Environment.NewLine, alunos));
            Console.WriteLine("-------------------------------");

            //ordenando: sort
            //alunos.Sort();
            //copiando: alunosEmLista
            List<string> alunosEmLista = new List<string>(alunos);
            //ordenando cópia
            alunosEmLista.Sort();
            //imprimindo cópia
            Console.WriteLine(string.Join(Environment.NewLine, alunosEmLista));
            Console.WriteLine("-------------------------------");

            Console.ReadLine();
        }

    }
}
