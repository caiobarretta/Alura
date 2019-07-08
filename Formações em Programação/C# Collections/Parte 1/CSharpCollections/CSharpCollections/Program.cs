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
            csharpColecoes.AdicionarAula(new Aula("Criando uma Aula", 20));
            csharpColecoes.AdicionarAula(new Aula("Modelando com coleções", 24));

            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricular(a1);
            csharpColecoes.Matricular(a2);
            csharpColecoes.Matricular(a3);

            foreach (var aluno in csharpColecoes.Alunos)
                Console.WriteLine(aluno);

            Console.WriteLine($"O aluno {a1.Nome} está matriculado?");
            Console.WriteLine(csharpColecoes.EstaMatriculado(a1));

            Aluno tonini = new Aluno("Vanessa Tonini", 34672);
            Console.WriteLine($"O aluno {a1.Nome} está matriculado?");
            Console.WriteLine(csharpColecoes.EstaMatriculado(tonini));

            //mas a1 == a Tonini?
            Console.WriteLine("a1 == a Tonini?");
            Console.WriteLine(a1 == tonini);

            //o que ocorreu? a1 é equals a Tonini?
            Console.WriteLine("a1 é equals a Tonini?");
            Console.WriteLine(a1.Equals(tonini));

            Console.ReadLine();
        }

    }
}
