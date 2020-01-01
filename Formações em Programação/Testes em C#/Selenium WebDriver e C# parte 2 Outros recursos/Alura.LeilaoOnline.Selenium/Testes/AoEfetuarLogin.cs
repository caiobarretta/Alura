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
    public class AoEfetuarLogin
    {
        private readonly IWebDriver _driver;
        private LoginPO loginPO;
        public AoEfetuarLogin(TestFixture fixture)
        {
            _driver = fixture.Driver;
            loginPO = new LoginPO(_driver);
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //Arrage
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("fulano@example.org", "123");

            //Act
            loginPO.SubmitForm();

            //Assert
            Assert.Contains("Dashboard", _driver.Title);
        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveContinuarLogin()
        {
            //Arrage
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("fulano@example.org", "");

            //Act
            loginPO.SubmitForm();

            //Assert
            Assert.Contains("Login", _driver.PageSource);
        }
    }
}
