using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;
        private HomeNaoLogadaPO homeNaoLogadaPO;
        public AoNavegarParaHomeMobile()
        {
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 400;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Custom";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel(), options);
        }

        [Fact]
        public void DataLargura400DeveMostrarMenuMobile()
        {
            //Arrange
            homeNaoLogadaPO = new HomeNaoLogadaPO(driver);

            //Act
            homeNaoLogadaPO.NavigateGoToUrl();

            //Assert
            Assert.True(homeNaoLogadaPO.Menu.MenuMobileVisivel);
        }

        public void Dispose() => driver.Quit();
    }
}
