using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
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
    }
}
