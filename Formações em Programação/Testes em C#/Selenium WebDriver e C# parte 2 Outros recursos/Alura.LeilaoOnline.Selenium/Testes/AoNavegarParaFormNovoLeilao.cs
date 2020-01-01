using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private readonly IWebDriver _driver;

        private LoginPO loginPO;
        private NovoLeilaoPO novoLeilaoPO;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;

            loginPO = new LoginPO(_driver);
            novoLeilaoPO = new NovoLeilaoPO(_driver);
        }

        [Fact]
        public void DadoLoginAdministrativoDeveMostrarTresCategorias()
        {
            //Arrage
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmitForm();

            //Act
            novoLeilaoPO.NavigateGoToUrl();


            //Assert
            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
