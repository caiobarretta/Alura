using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        private const string Url = "http://localhost:5000/Home/Detalhes/";

        private readonly IWebDriver _driver;
        private By byInputValor;
        private By byInputBtnDarLance;
        private By byInputLanceAtual;

        public int LanceAtual => (int.TryParse(_driver.FindElement(byInputLanceAtual).Text, out int result) ? result : 0);


        public DetalheLeilaoPO(IWebDriver driver)
        {
            _driver = driver;

            byInputValor = By.Id("Valor");
            byInputBtnDarLance = By.Id("btnDarLance");
            byInputLanceAtual = By.Id("lanceAtual");
        }


        public void NavigateGoToUrl(int idLeilao)
        {
            _driver.Navigate().GoToUrl(Url + idLeilao);
        }

        public void OfertaLance(double valorLance)
        {
            _driver.FindElement(byInputValor).SendKeys(valorLance.ToString());
            _driver.FindElement(byInputBtnDarLance).Click();
        }
    }
}
