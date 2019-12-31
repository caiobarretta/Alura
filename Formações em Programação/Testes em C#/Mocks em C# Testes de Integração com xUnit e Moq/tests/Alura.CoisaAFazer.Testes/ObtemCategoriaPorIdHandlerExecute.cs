using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.CoisaAFazer.Testes
{
    public class ObtemCategoriaPorIdHandlerExecute
    {
        [Fact]
        public void QuandoIdForExistenteDeveChamarCategoriaPorIdUmaUnicaVez()
        {
            //Arrage
            var idCategoria = 20;
            var comando = new ObtemCategoriaPorId(idCategoria);

            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;

            var handler = new ObtemCategoriaPorIdHandler(repo);

            //Act
            handler.Execute(comando);

            //Assert
            mock.Verify(r => r.ObtemCategoriaPorId(idCategoria), Times.Once());
        }
    }
}
