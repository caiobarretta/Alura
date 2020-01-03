using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuNaoLogadoPo
    {
        private IWebDriver _driver;
        private By byMenuMobile;

        public bool MenuMobileVisivel 
        {
            get
            {
                return _driver.FindElement(byMenuMobile).Displayed;
            }
        }

        public MenuNaoLogadoPo(IWebDriver driver)
        {
            _driver = driver;
            byMenuMobile = By.ClassName("sidenav-trigger");
        }

    }
}