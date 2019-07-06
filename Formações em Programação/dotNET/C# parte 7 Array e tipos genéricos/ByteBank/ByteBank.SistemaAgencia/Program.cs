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

            var conta = new ContaCorrente(1111, 1111111111);

            lista.Adicionar(conta);
            lista.Adicionar(new ContaCorrente(12312, 342433423));
            lista.Adicionar(new ContaCorrente(15462, 30879873));
            lista.Adicionar(new ContaCorrente(12987, 342467563));
            lista.Adicionar(new ContaCorrente(12987, 453454535));
            lista.Adicionar(new ContaCorrente(12987, 908098098));
            lista.Adicionar(new ContaCorrente(12987, 234242341));
            lista.Adicionar(new ContaCorrente(12987, 453434526));
            lista.Adicionar(new ContaCorrente(12987, 342467453));
            lista.Adicionar(new ContaCorrente(12987, 342453454));
            lista.Adicionar(new ContaCorrente(12987, 342468678));
            lista.Adicionar(new ContaCorrente(12987, 342090909));
            lista.Adicionar(new ContaCorrente(12987, 346698900));
            lista.Adicionar(new ContaCorrente(12987, 342490898));
            lista.Adicionar(new ContaCorrente(12987, 342342342));

            lista.EscreverListaNaTela();
            lista.Remover(conta);
            Console.WriteLine("-----------------------------------------------");
            lista.EscreverListaNaTela();

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