using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomeNaoLogadaPO
    {
        private IWebDriver _driver;
        private const string Url = "http://localhost:5000";

        public MenuNaoLogadoPo Menu { get; }

        public HomeNaoLogadaPO(IWebDriver driver)
        {
            _driver = driver;
            Menu = new MenuNaoLogadoPo(_driver);
        }

        public void NavigateGoToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
        }
    }
}
