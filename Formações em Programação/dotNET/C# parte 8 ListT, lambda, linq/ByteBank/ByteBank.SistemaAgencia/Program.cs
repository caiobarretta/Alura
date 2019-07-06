using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(1, 9),
                new ContaCorrente(9, 1),
                new ContaCorrente(5, 5),
                new ContaCorrente(5, 5),
                new ContaCorrente(6, 4),
                new ContaCorrente(4, 6)
            };


            // contas.Sort(); ~~> Chama a implementação dada em IComparable
            // contas.Sort(new ComparadorContaCorrenteAgencia());
            var contasOrdenadas = contas.OrderBy(conta => conta.Numero);

            //contas.ForEach(c => { Console.WriteLine(c); });
            foreach (var item in contasOrdenadas)
                Console.WriteLine(item);

            Console.ReadLine();
        }


        static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Welligton",
                "Guilherme",
                "Luana",
                "Ana"
            };

            nomes.Sort();

            foreach (var nome in nomes)
                Console.WriteLine(nome);

            var idades = new List<int>();
            idades.Add(5);
            idades.Add(453);
            idades.Add(0909);
            idades.Add(24543);
            idades.Add(4535);

            //ListExtensoes.AdicionarVarios(idades, 123, 123123, 123123, 4354534, 4654, 234);
            idades.AdicionarVarios(56456, 6757, 8978, 234, 546, 4234);
            idades.AdicionarVarios(-1, 999999);

            idades.Remove(5);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
                Console.WriteLine(idades[i]);

        }

        static void TestaListagenerica()
        {
            Lista<int> idades = new Lista<int>();
            idades.Adicionar(5);
            idades.AdicionarVarios(123, 123123, 123123, 4354534, 4654, 234);

            idades.Remover(5);

            for (int i = 0; i < idades.Tamanho; i++)
                Console.WriteLine(idades[i]);
        }

        static void TestaListaDeObject()
        {
            ListaObject idades = new ListaObject();
            idades.AdicionarVarios(1, 2, 3, 4, "teste");

            for (int i = 0; i < idades.Tamanho; i++)
                Console.WriteLine(idades[i]);
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            lista.AdicionarVarios(
                new ContaCorrente(1111, 1111111111), new ContaCorrente(15462, 308798734), new ContaCorrente(12987, 342467563),
                new ContaCorrente(12987, 453454535), new ContaCorrente(12987, 908098098), new ContaCorrente(12987, 234242341),
                new ContaCorrente(12987, 453434526), new ContaCorrente(12987, 342467453), new ContaCorrente(12987, 342453454),
                new ContaCorrente(12987, 342468678), new ContaCorrente(12987, 342090909), new ContaCorrente(12987, 346698900),
                new ContaCorrente(12987, 342490898), new ContaCorrente(12987, 342342342), new ContaCorrente(12312, 342433423));

            for (int i = 0; i < lista.Tamanho; i++)
                Console.WriteLine(lista[i]);
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