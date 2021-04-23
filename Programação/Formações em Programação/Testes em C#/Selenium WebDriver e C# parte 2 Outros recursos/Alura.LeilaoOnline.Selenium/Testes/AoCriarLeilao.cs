using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private readonly IWebDriver _driver;

        private LoginPO loginPO;
        private NovoLeilaoPO novoLeilaoPO;

        public AoCriarLeilao(TestFixture fixture)
        {
            _driver = fixture.Driver;

            loginPO = new LoginPO(_driver);
            novoLeilaoPO = new NovoLeilaoPO(_driver);
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //Arrage
            loginPO.NavigateGoToUrl();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmitForm();

            novoLeilaoPO.NavigateGoToUrl();
            novoLeilaoPO.PreencheFormulario(
                "Leilão Coleção 1",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam mi odio, molestie sed nulla quis, semper auctor felis. " +
                "Vestibulum imperdiet hendrerit turpis, ac aliquam tortor vulputate id. Nulla non fringilla sapien. Donec cursus, dolor et scelerisque maximus, metus ante porttitor est, " +
                "id laoreet augue purus a quam. Nam commodo sed massa at blandit. Proin aliquet orci velit, quis consequat erat mattis at. Ut suscipit nunc sem, eu suscipit risus vestibulum at. " +
                "Sed varius, sem vitae sodales dictum, metus felis aliquet neque, in accumsan eros eros quis erat. Mauris quis erat sed odio suscipit luctus eu accumsan mi. " +
                "Praesent dapibus est a ipsum mattis, vitae volutpat ipsum mollis. Aliquam sagittis nisi et fringilla gravida.",
                "Item de Colecionador",
                4000, @"C:\Users\Caio Barretta\Pictures\Harley Sportster Bobber.jpg", DateTime.Now, DateTime.Now.AddMonths(2));

            //Act
            novoLeilaoPO.SubmitForm();

            //Assert
            Assert.Contains("Leilões cadastrados no sistema", _driver.PageSource);
        }

    }
}
