using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.CoisaAFazer.Testes
{
    public class GerenciaPrazoDasTarefasHandlerExecute
    {
        [Fact]
        public void QuandoTarefasEstiveremAtrasadasDeveMudarSeuEstatus()
        {
            //Arrange
            var compCateg = new Categoria(1, "Compras");
            var casaCateg = new Categoria(2, "Casa");
            var trabCateg = new Categoria(3, "Trabalho");
            var saudCateg = new Categoria(4, "Saúde");
            var higiCateg = new Categoria(5, "Higiene");

            var tarefas = new List<Tarefa>
            {
                //atrasada a partir de 01/01/2019
                new Tarefa(1, "Tirar lixo", casaCateg, new DateTime(2018, 12, 31), null, StatusTarefa.Criada),
                new Tarefa(4, "Fazer o almoço", casaCateg, new DateTime(2017, 12, 1), null, StatusTarefa.Criada),
                new Tarefa(9, "Ir à academia", saudCateg, new DateTime(2018, 12, 31), null, StatusTarefa.Criada),
                new Tarefa(7, "Concluir o relatório", trabCateg, new DateTime(2018, 5, 7), null, StatusTarefa.Pendente),
                new Tarefa(10, "beber água", saudCateg, new DateTime(2018, 12, 31), null, StatusTarefa.Criada),
                //dentro do prazo em 1/1/2019
                new Tarefa(8, "Comparecer à reunião", trabCateg, new DateTime(2018, 11, 12), null, StatusTarefa.Concluida),
                new Tarefa(2, "Arrumar a cama", casaCateg, new DateTime(2019, 4, 5), null, StatusTarefa.Criada),
                new Tarefa(3, "Escovar os dentes", saudCateg, new DateTime(2019, 1, 2), null, StatusTarefa.Criada),
                new Tarefa(5, "Comprar presente pro João", compCateg, new DateTime(2019, 10, 8), null, StatusTarefa.Criada),
                new Tarefa(6, "Comprar ração", compCateg, new DateTime(2019, 11, 20), null, StatusTarefa.Criada)
            };

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);


            repo.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019, 1, 1));
            var handler = new GerenciaPrazoDasTarefasHandler(repo);

            //Act
            handler.Execute(comando);

            //Assert
            var tarefasEmAtraso = repo.ObtemTarefas(tarefa =>  tarefa.Status == StatusTarefa.EmAtraso);
            Assert.Equal(5, tarefasEmAtraso.Count());
        }
    }
}
