using Alura.LeilaoOnline.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoValorNegativo()
        {
            //Arrange - cenário
            var valorNegativo = -100;


            //Assert
            Assert.Throws<ArgumentException>(
                    //Act - Método sobre test
                    () => new Lance(null, valorNegativo)
            );
        }
    }
}
