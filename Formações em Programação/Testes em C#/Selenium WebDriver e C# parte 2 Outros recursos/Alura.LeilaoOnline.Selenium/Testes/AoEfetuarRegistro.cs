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
    public class AoEfetuarRegistro
    {
        private readonly IWebDriver _driver;
        private RegistroPO registroPO;
        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
            registroPO = new RegistroPO(_driver);
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //Arrage
            registroPO.NavigateGoToUrl();
            registroPO.PreencheFormulario(nome: "Caio Augusto Barretta", email: "caioabarretta@gmail.com", password: "123", confirmPassword: "123");

            //Action
            registroPO.SubmitForm();

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
            registroPO.NavigateGoToUrl();
            registroPO.PreencheFormulario(nome: nome, email: email, password: password, confirmPassword: confirmPassword);

            //Action
            registroPO.SubmitForm();

            //Assert
            Assert.Contains("section-registro", _driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrage
            registroPO.NavigateGoToUrl();

            //Action
            registroPO.SubmitForm();

            //Assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //Arrage
            registroPO.NavigateGoToUrl();
            registroPO.PreencheFormulario(nome: string.Empty, email: "caioabarretta", password: string.Empty, confirmPassword: string.Empty);

            //Action
            registroPO.SubmitForm();

            //Assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
