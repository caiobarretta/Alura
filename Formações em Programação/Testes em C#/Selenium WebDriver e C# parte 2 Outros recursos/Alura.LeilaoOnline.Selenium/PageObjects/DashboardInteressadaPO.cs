using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly IWebDriver _driver;

        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byInputBtnPesquisar;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;

            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byInputBtnPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(_driver.FindElement(bySelectCategorias), 1000);
            select.DeselectAll();
            categorias.ForEach(categ =>
            {
                Thread.Sleep(2000);
                select.SelectByText(categ);
            });

            _driver.FindElement(byInputTermo).SendKeys(termo);
            Thread.Sleep(2000);

            if (emAndamento)
            {
                var inputSwitch = _driver.FindElement(byInputAndamento);
                Thread.Sleep(2000);
                inputSwitch.Click();
            }

            Thread.Sleep(2000);
            _driver.FindElement(byInputBtnPesquisar).Click();
            Thread.Sleep(2000);
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = _driver.FindElement(byMeuPerfilLink);
            var linkLogout = _driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(_driver)
                //Mover para elemento pai
                .MoveToElement(linkMeuPerfil)
                //Mover para o link de logout
                .MoveToElement(linkLogout)
                //Clicar no link de logout
                .Click()
                .Build();

            acaoLogout.Perform();
        }
    }
}