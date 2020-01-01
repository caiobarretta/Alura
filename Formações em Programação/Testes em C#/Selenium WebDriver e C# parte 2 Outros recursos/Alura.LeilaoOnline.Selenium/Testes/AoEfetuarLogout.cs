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
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixtuxe)
        {
            this.driver = fixtuxe.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.NavigateGoToUrl();

            loginPO.PreencheFormulario("fulano@exemplo", "123");
            loginPO.SubmitForm();

            //Act

            //Assert
            Assert.Contains("Proximos Leilões", driver.PageSource);
        }
    }
}
