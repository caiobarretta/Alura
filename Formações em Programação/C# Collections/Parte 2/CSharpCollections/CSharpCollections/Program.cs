using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
        {
            List<Mes> meses = new List<Mes>
            {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30),
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            //Pegar o primeiro trimestre
            foreach (var item in meses.Take(3))
                Console.WriteLine(item);

            Console.Clear();
            //Pegar os meses depois do primeiro trimestre
            foreach (var item in meses.Skip(3))
                Console.WriteLine(item);

            Console.Clear();
            //Pegar os meses do terceiro trimestre
            foreach (var item in meses.Skip(6).Take(3))
                Console.WriteLine(item);

            Console.Clear();
            //pegar os meses até que até que o mês comece com a letra 'S'
            foreach (var item in meses.TakeWhile(m => !m.Nome.ToUpper().StartsWith("S")))
                Console.WriteLine(item);

            Console.Clear();
            //Pular os meses até que o mês comece com a letra 'S'
            foreach (var item in meses.SkipWhile(m => !m.Nome.ToUpper().StartsWith("S")))
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
