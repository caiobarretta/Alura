using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void CovarianciaDeIEnumerable(string[] args)
        {
            Console.WriteLine("string para object");
            string titulo = "meses";
            object obj = titulo;
            Console.WriteLine(obj);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("List<string> para List<object>");
            IList<string> listaMeses = new List<string>()
            {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Dezembro", "Outubro", "Novembro"
            };
            //IList<object> listaObj = listaMeses;
            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            Console.WriteLine("string[] para object[]");// covariância
            string[] arrayMeses = new string[]
            {
                "Janeiro", "Fevereiro", "Março",
                "Abril", "Maio", "Junho",
                "Julho", "Agosto", "Setembro",
                "Dezembro", "Outubro", "Novembro"
            };

            object[] arrayObj = arrayMeses;
            Console.WriteLine(arrayObj);
            foreach (var item in arrayObj)
                Console.WriteLine(item);

            Console.WriteLine("-------------------------------");
            arrayObj[0] = "Primeiro mês";
            foreach (var item in arrayObj)
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------");
            //arrayObj[0] = 12345;
            //foreach (var item in arrayObj)
            //    Console.WriteLine(item);
            //Console.WriteLine("-------------------------------");

            Console.WriteLine("List<string> para IEnumerable<object>");
            IEnumerable<object> enumObj = listaMeses; //covariância
            foreach (var item in enumObj)
                Console.WriteLine(item);
            Console.WriteLine("-------------------------------");
            //enumObj[0] = 12345;

            Console.ReadLine();
        }
    }
}
