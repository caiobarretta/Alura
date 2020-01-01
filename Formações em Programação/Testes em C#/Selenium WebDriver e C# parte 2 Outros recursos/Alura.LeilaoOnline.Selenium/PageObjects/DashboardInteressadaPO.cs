using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private readonly IWebDriver _driver;

        private By byLogoutLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;

            byLogoutLink = By.Id("logout");
        }

        public void EfetuarLogout()
        {
            _driver.FindElement(byLogoutLink).Click();
        }
    }
}