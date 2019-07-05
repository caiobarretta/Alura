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
            {
                acumulador += idades[indice];
            }

            Console.WriteLine($"A média é: {acumulador / idades.Length}");

            Console.ReadLine();
        }
    }
}