using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly IWebDriver _driver;

        private By byLogoutLink;
        private By byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;

            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
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