using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private const string Url = "http://localhost:5000/Leiloes/Novo";

        private readonly IWebDriver _driver;

        private By inputTitulo;
        private By inputDescricao;
        private By inputCategoria;
        private By inputValorInicial;
        private By inputImagem;
        private By inputInicioPregrao;
        private By inputTerminoPregao;

        private By inputBtnSalvar;

        public IEnumerable<string> Categorias 
        {
            get
            {
                return new SelectElement(_driver.FindElement(inputCategoria)).Options
                    .Where(o => o.Enabled)
                    .Select(o => o.Text);
            }
        }


        public NovoLeilaoPO(IWebDriver driver)
        {
            _driver = driver;

            inputTitulo = By.Id("Titulo");
            inputDescricao = By.Id("Descricao");
            inputCategoria = By.ClassName("select-wrapper");
            inputValorInicial = By.Id("ValorInicial");
            inputImagem = By.Id("ArquivoImagem");
            inputInicioPregrao = By.Id("InicioPregao");
            inputTerminoPregao = By.Id("TerminoPregao");
            inputBtnSalvar = By.CssSelector("button[type=submit]");
        }


        public void NavigateGoToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void PreencheFormulario(string titulo, string descricao, string categoria, double valorInicial, string imagem, DateTime inicioPregrao, DateTime terminoPregao)
        {
            _driver.FindElement(inputTitulo).SendKeys(titulo);
            _driver.FindElement(inputDescricao).SendKeys(descricao);

            var select = new SelectMaterialize(_driver.FindElement(inputCategoria));
            select.DeselectAll();
            select.SelectByText(categoria);

            _driver.FindElement(inputValorInicial).SendKeys(valorInicial.ToString());
            _driver.FindElement(inputImagem).SendKeys(imagem);
            _driver.FindElement(inputInicioPregrao).SendKeys(inicioPregrao.ToString("dd/MM/yyyy"));
            _driver.FindElement(inputTerminoPregao).SendKeys(terminoPregao.ToString("dd/MM/yyyy"));
        }

        public void SubmitForm()
        {
            _driver.FindElement(inputBtnSalvar).Submit();
        }
    }
}
