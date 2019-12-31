﻿using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.CoisaAFazer.Testes
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasDeveRetornar200()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("DbTarefasContext")
                .Options;
            var contexto = new DbTarefasContext(options);

            contexto.Categorias.Add(new Categoria(20, "Estudo"));
            contexto.SaveChanges();

            var repo = new RepositorioTarefa(contexto);

            var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var controlador = new TarefasController(repo, mockLogger.Object);
            CadastraTarefaVM model = new CadastraTarefaVM()
            {
                IdCategoria = 20,
                Titulo = "Estudar xUnit",
                Prazo = new DateTime(2019, 12, 31)
            };

            //Act
            var actionResult = controlador.EndpointCadastraTarefa(model);

            //Assert
            Assert.IsType<OkResult>(actionResult);//200
        }
    }
}
