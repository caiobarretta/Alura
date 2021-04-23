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

        public FiltroLeiloesPO Filtro { get; }
        public MenuLogadoPO Menu { get; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            _driver = driver;

            Filtro = new FiltroLeiloesPO(_driver);

            Menu = new MenuLogadoPO(_driver);

        }

        
    }
}