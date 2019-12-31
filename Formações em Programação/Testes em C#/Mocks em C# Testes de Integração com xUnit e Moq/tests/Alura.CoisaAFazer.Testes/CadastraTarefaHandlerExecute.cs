using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
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
            var tituloTarefa = "Estuda XUnit";
            var comando = new CadastraTarefa(tituloTarefa, new Categoria("estudo"), new DateTime(2019, 12, 31));


            var mock = new Mock<ILogger<CadastraTarefaHandler>>();
            var logger = mock.Object;

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler(repo, logger);
            handler.Execute(comando);

            //Assert
            var tarefa = repo.ObtemTarefas(tarefa => tarefa.Titulo == tituloTarefa).FirstOrDefault();
            Assert.NotNull(tarefa);
        }

        delegate void CapturaMensagemLog(LogLevel logLevel, EventId eventId, object state, Exception exception, Func<Object, Exception, string> formatter);

        [Fact]
        public void DadaTarefaComInformacoesValidasDeveLogar()
        {
            //Arrange
            //Cria comando
            var tituloTarefa = "Estuda XUnit";
            var comando = new CadastraTarefa(tituloTarefa, new Categoria("estudo"), new DateTime(2019, 12, 31));

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            LogLevel levelCapturado = LogLevel.None;
            CapturaMensagemLog captura = (logLevel, eventId, state, exception, formatter) =>
            {
                levelCapturado = logLevel;
            };

            mockLogger.Setup(l =>
                l.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<Object, Exception, string>>()
                    )).Callback(captura);

            var logger = mockLogger.Object;

            var mock = new Mock<IRepositorioTarefas>();
            var repo = mock.Object;

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler(repo, logger);
            handler.Execute(comando);

            //Assert
            Assert.Equal(LogLevel.None, levelCapturado);

        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            //Arrange
            var mock = new Mock<ILogger<CadastraTarefaHandler>>();
            var logger = mock.Object;

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler(repo, logger);
            CommandResult result = handler.Execute(null);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalseMock()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();
            var logger = mockLogger.Object;

            var tituloTarefa = "Estuda XUnit";
            var comando = new CadastraTarefa(tituloTarefa, new Categoria("estudo"), new DateTime(2019, 12, 31));
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro na inclusão de tarefas."));
            var repo = mock.Object;

            //Act
            var handler = new CadastraTarefaHandler(repo, logger);
            CommandResult result = handler.Execute(comando);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemExcessaoMock()
        {
            //Arrange
            var mensagemDeErroEsperada = "Houve um erro na inclusão de tarefas.";
            var excessaoEsperada = new Exception(mensagemDeErroEsperada);

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();
            var logger = mockLogger.Object;

            var tituloTarefa = "Estuda XUnit";
            var comando = new CadastraTarefa(tituloTarefa, new Categoria("estudo"), new DateTime(2019, 12, 31));

            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa>()))
                .Throws(excessaoEsperada);
            var repo = mock.Object;

            //Act
            var handler = new CadastraTarefaHandler(repo, logger);
            CommandResult result = handler.Execute(comando);

            //Assert
            mockLogger.Verify(l => 
                l.Log(LogLevel.Error, 
                    It.IsAny<EventId>(), 
                    It.IsAny<object>(),
                    excessaoEsperada, 
                    It.IsAny<Func<Object, Exception, string>>()), 
                Times.Never());
        }
    }
}
