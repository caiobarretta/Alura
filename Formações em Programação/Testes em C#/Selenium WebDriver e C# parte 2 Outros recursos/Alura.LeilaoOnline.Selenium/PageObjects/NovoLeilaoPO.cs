using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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

        public NovoLeilaoPO(IWebDriver driver)
        {
            _driver = driver;

            inputTitulo = By.Id("Titulo");
            inputDescricao = By.Id("Descricao");
            inputCategoria = By.Id("Categoria");
            inputValorInicial = By.Id("ValorInicial");
            inputImagem = By.Id("Imagem");
            inputInicioPregrao = By.Id("InicioPregao");
            inputTerminoPregao = By.Id("TerminoPregao");
        }

        public void NavigateGoToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void PreencheFormulario(string titulo, string descricao, string categoria, double valorInicial, string imagem, DateTime inicioPregrao, DateTime terminoPregao)
        {
            _driver.FindElement(inputTitulo).SendKeys(titulo);
            _driver.FindElement(inputDescricao).SendKeys(descricao);
            _driver.FindElement(inputCategoria).SendKeys(categoria);
            _driver.FindElement(inputValorInicial).SendKeys(valorInicial.ToString());
            _driver.FindElement(inputImagem).SendKeys(imagem);
            _driver.FindElement(inputInicioPregrao).SendKeys(inicioPregrao.ToString());
            _driver.FindElement(inputTerminoPregao).SendKeys(terminoPregao.ToString());
        }
    }
}
