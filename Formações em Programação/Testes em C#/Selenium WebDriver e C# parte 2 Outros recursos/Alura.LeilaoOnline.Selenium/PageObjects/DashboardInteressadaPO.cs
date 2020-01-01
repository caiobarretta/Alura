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
        }

        public void PesquisarLeiloes(List<string> categorias)
        {
            var select = new SelectMaterialize(_driver.FindElement(bySelectCategorias));
            select.DeselectAll();
            categorias.ForEach(categ => select.SelectByText(categ));
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