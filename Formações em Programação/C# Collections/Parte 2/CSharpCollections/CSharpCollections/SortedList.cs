using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    partial class Program
    {
        static void SortedList()
        {
            //Vamos criar um dicionário de aluno
            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>();
            //VT, Vanessa, 34672
            alunos.Add("VT", new Aluno("Vanessa", 34672));
            //AL, Ana, 5617
            alunos.Add("AL", new Aluno("Ana", 5617));
            //RN, Rafael, 17645
            alunos.Add("RN", new Aluno("Rafael", 17645));
            //WM, Wanderson, 11287
            alunos.Add("WM", new Aluno("Wanderson", 11287));
            Imprimir(alunos);

            //vamos remover: AL
            alunos.Remove("AL");
            //vamos adicionar: MO
            alunos.Add("MO", new Aluno("Marcelo", 12345));
            Imprimir(alunos);

            IDictionary<string, Aluno> sorted = new SortedList<string, Aluno>();
            sorted.Add("VT", new Aluno("Vanessa", 34672));
            sorted.Add("AL", new Aluno("Ana", 5617));
            sorted.Add("RN", new Aluno("Rafael", 17645));
            sorted.Add("WM", new Aluno("Wanderson", 11287));
            Imprimir(sorted);

            Console.ReadLine();
        }

        static void Imprimir(IDictionary<string, Aluno> dicionario)
        {
            Console.WriteLine("-------------------------------");
            foreach (var item in dicionario)
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------");
        }
    }
}
