using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    internal class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;

            byLogoutLink = By.Id("logout");
        }

        public void EfetuarLogout()
        {
            driver.FindElement(byLogoutLink);
        }
    }
}