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

        [Fact]
        public void DadaLargura992DeveMostrarMenuMobile()
        {
            //Arrange
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 992;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Custom";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel(), options);

            homeNaoLogadaPO = new HomeNaoLogadaPO(driver);

            //Act
            homeNaoLogadaPO.NavigateGoToUrl();

            //Assert
            Assert.True(homeNaoLogadaPO.Menu.MenuMobileVisivel);
        }

        [Fact]
        public void DadaLargura993NaoDeveMostrarMenuMobile()
        {
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 993;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Custom";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);
            driver = new ChromeDriver(TestHelper.PastaDoExecutavel(), options);

            //Arrange
            homeNaoLogadaPO = new HomeNaoLogadaPO(driver);

            //Act
            homeNaoLogadaPO.NavigateGoToUrl();


            //Assert
            homeNaoLogadaPO.NavigateGoToUrl();

        }

        public void Dispose() => driver.Quit();
    }
}
