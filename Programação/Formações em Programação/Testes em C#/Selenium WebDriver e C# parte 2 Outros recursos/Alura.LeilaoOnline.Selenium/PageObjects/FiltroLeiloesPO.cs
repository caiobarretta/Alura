using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private readonly IWebDriver _driver;

        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byInputBtnPesquisar;


        public FiltroLeiloesPO(IWebDriver driver)
        {
            _driver = driver;

            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byInputBtnPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(_driver.FindElement(bySelectCategorias), 1000);
            select.DeselectAll();
            categorias.ForEach(categ =>
            {
                Thread.Sleep(2000);
                select.SelectByText(categ);
            });

            _driver.FindElement(byInputTermo).SendKeys(termo);
            Thread.Sleep(2000);

            if (emAndamento)
            {
                var inputSwitch = _driver.FindElement(byInputAndamento);
                Thread.Sleep(2000);
                inputSwitch.Click();
            }

            Thread.Sleep(2000);
            _driver.FindElement(byInputBtnPesquisar).Click();
            Thread.Sleep(2000);
        }
    }
}
