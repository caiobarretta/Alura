using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Services.Models;
using Microsoft.EntityFrameworkCore;
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

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler(repo);
            handler.Execute(comando);

            //Assert
            var tarefa = repo.ObtemTarefas(tarefa => tarefa.Titulo == tituloTarefa).FirstOrDefault();
            Assert.NotNull(tarefa);
        }


        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
        {
            //Arrange
            //Cria comando

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler(repo);
            CommandResult result = handler.Execute(null);

            //Assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalseMock()
        {
            //Arrange
            //Cria comando
            var mock = new Mock<IRepositorioTarefas>();
            mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro na inclusão de tarefas."));
            var repo = mock.Object;

            //Act
            //Executar comando
            var handler = new CadastraTarefaHandler(repo);
            CommandResult result = handler.Execute(null);

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}
