using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void SetEDictionary()
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

            //limpando o console
            Console.Clear();

            //já temos método para saber se o aluno está matriculado.
            //mas agora precisamos buscar aluno por número de matrícula

            //pergunta: "Quem é o aluno com matrícula 5617?"
            Console.WriteLine("Quem é o aluno com matrícula 5617?");
            //implementando Curso.BuscaMatriculado
            Aluno aluno5617 = csharpColecoes.BuscaMatriculado(5617);
            Console.WriteLine(aluno5617);

            //quem é o aluno 5618?
            Console.WriteLine("Quem é o aluno 5618?");
            Console.WriteLine(csharpColecoes.BuscaMatriculado(5618));

            //adicionar aluno de matrícula igual
            Aluno fabio = new Aluno("Fabio Gushiken", 5617);
            //csharpColecoes.Matricular(fabio);
            //e se quisermos trocar o aluno que tem a mesma chave?
            csharpColecoes.SubstituirAluno(fabio);
            Console.WriteLine("Quem é o aluno com matrícula 5617?");
            Console.WriteLine(csharpColecoes.BuscaMatriculado(5617));


            Console.ReadLine();
        }

    }
}
