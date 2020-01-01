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

        [Theory]
        [InlineData("", "caioabarretta@gmail.com", "123", "123")]
        [InlineData("Caio Augusto Barretta", "", "123", "123")]
        [InlineData("Caio Augusto Barretta", "caioabarretta", "123", "123")]
        [InlineData("Caio Augusto Barretta", "caioabarretta@gmail.com", "", "123")]
        [InlineData("Caio Augusto Barretta", "caioabarretta@gmail.com", "123", "")]
        public void DadoInfoInvalidasDeveIrContinuarNaHome(string nome, string email, string password, string confirmPassword)
        {
            //Arrage
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = _driver.FindElement(By.Id("Nome"));
            inputNome.SendKeys(nome);

            //Email
            var inputEmail = _driver.FindElement(By.Id("Email"));
            inputEmail.SendKeys(email);

            //Password
            var inputPassword = _driver.FindElement(By.Id("Password"));
            inputPassword.SendKeys(password);

            //ConfirmPassword
            var inputConfirmPassword = _driver.FindElement(By.Id("ConfirmPassword"));
            inputConfirmPassword.SendKeys(confirmPassword);

            //Action
            var btnRegistro = _driver.FindElement(By.Id("btnRegistro"));
            btnRegistro.Click();

            //Assert
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrage
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Nome
            var inputNome = _driver.FindElement(By.Id("Nome"));
            inputNome.Clear();

            //Action
            var btnRegistro = _driver.FindElement(By.Id("btnRegistro"));
            btnRegistro.Click();

            //Assert
        }
    }
}
