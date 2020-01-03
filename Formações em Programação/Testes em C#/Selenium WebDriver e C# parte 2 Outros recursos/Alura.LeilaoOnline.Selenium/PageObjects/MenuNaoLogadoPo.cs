using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPo
    {
        private IWebDriver _driver;

        public bool MenuMobileVisivel { get; }

        public MenuNaoLogadoPo(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}