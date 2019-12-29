using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {

        [Fact]
        public void NaoAceitaProximoLanceDadoMesmoClienteRealizouUltimoLance()
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);

            //Act - Método sobre test
            leilao.RecebeLance(fulano, 1000);

            //Assert
            var qtdEsperada = 1;
            Assert.Equal(qtdEsperada, leilao.Lances.Count());
        }

        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        [InlineData(2, new double[] { 800, 900})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(
            int qtdEsperada, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var sicrano = new Interessada("Sicrano", leilao);

            leilao.IniciaPregao();

            for (int i = 0; i < ofertas.Length; i++)
            {
                var valor = ofertas[i];
                if ((i%2) == 0)
                    leilao.RecebeLance(fulano, valor);
                else
                    leilao.RecebeLance(sicrano, valor);
            }
            leilao.TerminaPregao();

            //Act - Método sobre test
            leilao.RecebeLance(fulano, 1000);

            //Assert
            Assert.Equal(qtdEsperada, leilao.Lances.Count());
        }
    }
}
