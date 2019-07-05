using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            lista.Adicionar(new ContaCorrente(12312, 342433423));
            lista.Adicionar(new ContaCorrente(15462, 30879873));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 342467563));

            Console.ReadLine();
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(1234, 13423423),
                new ContaCorrente(1234, 34543456),
                new ContaCorrente(1234, 80809809)
            };


            for (int i = 0; i < contas.Length; i++)
                Console.WriteLine(contas[i]);

        }

        static void TestaArrayInt()
        {
            //ARRAY de inteiros, com 5 posições.
            //int[] idades = null;
            int[] idades = new int[6];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;
            idades[5] = 60;

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
                acumulador += idades[indice];

            Console.WriteLine($"A média é: {acumulador / idades.Length}");
        }
    }
}