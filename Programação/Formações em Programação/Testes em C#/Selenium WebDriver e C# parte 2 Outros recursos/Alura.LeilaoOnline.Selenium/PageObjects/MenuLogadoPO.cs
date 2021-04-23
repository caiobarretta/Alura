using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private readonly IWebDriver _driver;

        private By byLogoutLink;
        private By byMeuPerfilLink;
        private By ByTableMinhasOfertas;

        public MenuLogadoPO(IWebDriver driver)
        {
            _driver = driver;

            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            ByTableMinhasOfertas = By.XPath("//table/tbody/tr[last()]");
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
