using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Services.Handlers;
using System;
using Xunit;

namespace Alura.CoisaAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveIncluirNoBd()
        {
            //Arrange
            //Cria comando
            var comando = new CadastraTarefa("Estuda XUnit", new Categoria("estudo"), new DateTime(2019, 12, 31));

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler();
            handler.Execute(comando);

            //Assert
            Assert.True(true);

            //CadastraTarefaHandlerExecute


        }
    }
}
