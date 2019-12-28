using Alura.LeilaoOnline.Core;
using System;

namespace Alura.LeilaoOnline.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            LeilaoComVariosLances();
            LeilaoComUmLance();
        }

        private static void Verifica(int valorEsperado, double valorObtido)
        {
            var cor = Console.ForegroundColor;
            if (valorEsperado == valorObtido)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teste Ok");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Teste Falhou. Esperado: {valorEsperado}, Obtido: {valorObtido}");
            }
            Console.ForegroundColor = cor;
        }

        private static void LeilaoComUmLance()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorEsperado = 900;
            var valorObtido = ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }

        private static void LeilaoComVariosLances()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            var maria = new Interessada("Maria", leilao);
            leilao.RecebeLance(maria, 900);

            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);


            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorEsperado = 1000;
            var valorObtido = ganhador.Valor;

            Verifica(valorEsperado, valorObtido);
        }
    }
}
