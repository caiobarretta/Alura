using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void ConsultasComLINQ()
        {
            //Problema: obter os nomes dos meses do ano
            //que tem 31 dias, em maiúsculo e em ordem alfabética

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

            //meses.Sort();
            //foreach (var mes in meses)
            //{
            //    if (mes.Dias == 31)
            //        Console.WriteLine(mes.Nome.ToUpper());
            //}

            //LINQ = CONSULTA INTEGRADA À LINGUAGEM
            IEnumerable<Mes> consulta = meses.Where(m => m.Dias == 31).OrderBy(m => m.Nome).Select(m => new Mes(m.Nome.ToUpper(), m.Dias));

            foreach (var item in consulta)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
