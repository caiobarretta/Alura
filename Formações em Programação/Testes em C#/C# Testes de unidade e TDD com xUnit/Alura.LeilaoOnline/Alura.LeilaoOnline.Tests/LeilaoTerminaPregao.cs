using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(1200, 1250, new double[] { 800, 1150, 1400, 1250 })]
        public void RetornaValorSuperiorMaisProximoDadoLeilaoNessaModalidade(double valorDestino, double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário
            IModalidadeAvaliacao modalidade = new OfertaSuperiorMaisProxima(valorDestino);

            var leilao = new Leilao("Van Gogh", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var sicrano = new Interessada("Sicrano", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                    leilao.RecebeLance(fulano, valor);
                else
                    leilao.RecebeLance(sicrano, valor);
            }

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorObtido = ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDadoLeilaoComPeloMenosUmlance(double valorEsperado, double[] ofertas)
        {
            //Arrange - cenário
            IModalidadeAvaliacao modalidade = new MaiorValor();

            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var sicrano = new Interessada("Sicrano", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i % 2) == 0)
                    leilao.RecebeLance(fulano, valor);
                else
                    leilao.RecebeLance(sicrano, valor);
            }

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorObtido = ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");

            //Assert
            var execaoObtida = Assert.Throws<InvalidOperationException>(
                    //Act - Método sobre test
                    () => leilao.TerminaPregao()
                );

            var msgEsperada = "Não é possível terminar o pregão sem que ele tenha começado. Para isso, utilize o método IniciaPregao().";
            Assert.Equal(msgEsperada, execaoObtida.Message);
        }

        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act - Método sobre test
            leilao.TerminaPregao();
            var ganhador = leilao.Ganhador;

            //Assert
            var valorEsperado = 0;
            var valorObtido = ganhador.Valor;

            Assert.Equal(valorEsperado, valorObtido);
        }

    }
}
