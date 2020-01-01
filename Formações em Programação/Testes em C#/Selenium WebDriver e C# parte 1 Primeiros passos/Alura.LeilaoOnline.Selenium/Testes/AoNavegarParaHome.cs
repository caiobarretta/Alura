using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome
    {
        private readonly IWebDriver _driver;
        //Setup
        public AoNavegarParaHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //Arrage
            //Act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Leil�es", _driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarPr�ximosLeil�esNaP�gina()
        {
            //Arrage
            //Act
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Pr�ximos Leil�es", _driver.PageSource);
        }
    }
}
