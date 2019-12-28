using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTestes
    {

        [Fact]
        public void LeilaoSemLances()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorEsperado = 0;
            var valorObtido = ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComTresClientes()
        {
            //Arrange - cenário
            //Dado leilão com 3 clientes e lances realizados por eles
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            var maria = new Interessada("Maria", leilao);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);

            leilao.RecebeLance(fulano, 1000);

            var beltrano = new Interessada("Beltrano", leilao);
            leilao.RecebeLance(beltrano, 1400);

            //Act - Método sobre test
            //Quando o leilão termina
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            //Então o valor esperado é o maior valor dado
            // e o cliente ganhador é oque deu o maior lance
            var valorEsperado = 1400;
            var valorObtido = ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(beltrano, ganhador.Cliente);
        }

        [Fact]
        public void LeilaoComLancesOrdenadosPorValor()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            var maria = new Interessada("Maria", leilao);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(maria, 990);

            leilao.RecebeLance(fulano, 1000);

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorEsperado = 1000;
            var valorObtido = ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComUmLance()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.RecebeLance(fulano, 800);

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorEsperado = 800;
            var valorObtido = ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComVariosLances()
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

            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
