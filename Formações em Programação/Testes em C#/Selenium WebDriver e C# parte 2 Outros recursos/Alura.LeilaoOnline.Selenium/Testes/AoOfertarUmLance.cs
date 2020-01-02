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
    public class AoOfertarUmLance
    {
        private readonly IWebDriver _driver;

        private LoginPO loginPO;
        private DetalheLeilaoPO detalheLeilaoPO;

        public AoOfertarUmLance(TestFixture fixture)
        {
            _driver = fixture.Driver;

            loginPO = new LoginPO(_driver);
            detalheLeilaoPO = new DetalheLeilaoPO(_driver);
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //Arrange
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmitForm();

            detalheLeilaoPO.NavigateGoToUrl(1);

            //Act
            detalheLeilaoPO.OfertaLance(300);


            //Assert
            Assert.Equal(300, detalheLeilaoPO.LanceAtual);
        }
    }
}
