using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private readonly IWebDriver _driver;
        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //Arrage
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = _driver.FindElement(By.Id("Nome"));
            inputNome.SendKeys("Caio Augusto Barretta");

            //Email
            var inputEmail = _driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys("caioabarretta@gmail.com");

            //Password
            var inputPassword = _driver.FindElement(By.Id("Password"));
            inputPassword.SendKeys("123");

            //ConfirmPassword
            var inputConfirmPassword = _driver.FindElement(By.Id("ConfirmPassword"));
            inputConfirmPassword.SendKeys("123");

            //Action
            var btnRegistro = _driver.FindElement(By.Id("btnRegistro"));
            btnRegistro.Click();

            //Assert
            Assert.Contains("Obrigado", _driver.PageSource);
        }
    }
}
