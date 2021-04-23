using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static void LinkedList()
        {
            LinkedList<string> dias = new LinkedList<string>();
            var d4 = dias.AddFirst("quarta");
            Console.WriteLine("d4.Value: {0}", d4.Value);
            Console.WriteLine("-------------------------------");

            var d2 = dias.AddBefore(d4, "segunda");

            var d3 = dias.AddAfter(d2, "terça");

            var d6 = dias.AddAfter(d4, "sexta");

            var d7 = dias.AddAfter(d6, "sábado");

            var d5 = dias.AddBefore(d6, "quinta");

            var d1 = dias.AddBefore(d2, "domingo");

            foreach (var dia in dias)
                Console.WriteLine(dia);
            Console.WriteLine("-------------------------------");

            var quarta = dias.Find("quarta");
            Console.WriteLine(quarta.Value);
            Console.WriteLine("-------------------------------");

            dias.Remove("quarta");
            foreach (var dia in dias)
                Console.WriteLine(dia);
            Console.WriteLine("-------------------------------");

            Console.ReadLine();
        }

    }
}
