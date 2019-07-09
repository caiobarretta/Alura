using System;
using System.Collections.Generic;

namespace CSharpCollections
{
    partial class Program
    {
        static void Main(string[] args)
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

            meses.Sort();
            foreach (var mes in meses)
            {
                if (mes.Dias == 31)
                    Console.WriteLine(mes.Nome.ToUpper());
            }

            Console.ReadLine();
        }
    }
}
