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

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void LeilaoComVariosLances(double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(fulano, oferta);
            }

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorObtido = ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

    }
}
