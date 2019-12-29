using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeOferta
    {
        [Theory]
        [InlineData(4, new double[] { 1000, 1200, 1400, 1300})]
        [InlineData(2, new double[] { 800, 900})]
        public void NaoPermiteNovosLancesDadoLeilaoFinalizado(
            int qtdEsperada, double[] ofertas)
        {
            //Arrange - cenário
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.IniciaPregao();
            foreach (var oferta in ofertas)
            {
                leilao.RecebeLance(fulano, oferta);
            }
            leilao.TerminaPregao();

            //Act - Método sobre test
            leilao.RecebeLance(fulano, 1000);

            //Assert
            Assert.Equal(qtdEsperada, leilao.Lances.Count());
        }
    }
}
