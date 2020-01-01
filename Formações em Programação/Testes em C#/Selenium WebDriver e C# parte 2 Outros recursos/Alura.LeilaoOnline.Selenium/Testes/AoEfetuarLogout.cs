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
        private IWebDriver _driver;

        private LoginPO loginPO;
        private DashboardInteressadaPO dashboardInteressadaPO;

        public AoEfetuarLogout(TestFixture fixtuxe)
        {
           _driver = fixtuxe.Driver;

            loginPO = new LoginPO(_driver);
            dashboardInteressadaPO = new DashboardInteressadaPO(_driver);
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //Arrange
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmitForm();

            //Act
            dashboardInteressadaPO.EfetuarLogout();

            //Assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
