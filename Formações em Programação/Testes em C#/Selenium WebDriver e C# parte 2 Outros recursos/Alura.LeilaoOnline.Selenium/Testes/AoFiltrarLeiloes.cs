using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private readonly IWebDriver _driver;

        private LoginPO loginPO;
        private DashboardInteressadaPO dashboardInteressadaPO;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            _driver = fixture.Driver;

            loginPO = new LoginPO(_driver);
            dashboardInteressadaPO = new DashboardInteressadaPO(_driver);
        }

        [Fact]
        public void DadoLoginInteressadaAoFiltrarLeiloesDeveMostrarPainelInteressada()
        {
            //Arrange
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmitForm();

            //Act
            dashboardInteressadaPO.PesquisarLeiloes(new List<string>() { "Arte", "Coleções" }, String.Empty, true);

            //Assert
            Assert.Contains("Resultado da pesquisa", _driver.PageSource);
        }
    }
}
