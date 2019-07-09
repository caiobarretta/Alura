using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCollections
{
    partial class Program
    {
        static Queue<string> pedagio = new Queue<string>();
        static void Main(string[] args)
        {
            //entrou: van
            Enfileirar("van");
            //entrou: kombi
            Enfileirar("kombi");
            //entrou guincho
            Enfileirar("guincho");
            //entrou pickup
            Enfileirar("pickup");
            
            //carro liberado
            Desenfileirar();
            //carro liberado
            Desenfileirar();
            //carro liberado
            Desenfileirar();
            //carro liberado
            Desenfileirar();
            //carro liberado
            Desenfileirar();

            Console.ReadLine();
        }

        private static void Desenfileirar()
        {
            if (pedagio.Any())
            {
                if (pedagio.Peek() == "guincho")
                    Console.WriteLine("Guincho está fazendo pagamento.");
                Console.WriteLine("Saiu da fila: {0}", pedagio.Dequeue());
                ImprimirForEach(pedagio);
            }
        }

        private static void Enfileirar(string veiculo)
        {
            Console.WriteLine("Entrou na fila: {0}", veiculo);
            pedagio.Enqueue(veiculo);
            ImprimirForEach(pedagio);
        }

        static void ImprimirForEach(Queue<string> lista)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Fila: ");
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------------------------------");
        }

    }
}
