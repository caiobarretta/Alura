using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        private const string Url = "http://localhost:5000";

        private readonly IWebDriver _driver;
        private By byFormRegistro;
        private By byInputNome;
        private By byInputEmail;
        private By byInputPassword;
        private By byInputConfirmPassword;
        private By byInputBtnRegistro;

        private By bySpanErroNome;
        private By bySpanErroEmail;


        public string NomeMensagemErro => _driver.FindElement(bySpanErroNome).Text;
        public string EmailMensagemErro => _driver.FindElement(bySpanErroEmail).Text;

        public RegistroPO(IWebDriver driver)
        {
            _driver = driver;

            byFormRegistro = By.TagName("Form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byInputConfirmPassword = By.Id("ConfirmPassword");
            byInputBtnRegistro = By.Id("btnRegistro");

            bySpanErroNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void PreencheFormulario(string nome, string email, string password, string confirmPassword)
        {
            _driver.FindElement(byInputNome).SendKeys(nome);//Nome
            _driver.FindElement(byInputEmail).SendKeys(email);//Email
            _driver.FindElement(byInputPassword).SendKeys(password);//Password
            _driver.FindElement(byInputConfirmPassword).SendKeys(confirmPassword);//ConfirmPassword
        }

        public void NavigateGoToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void SubmitForm()
        {
            _driver.FindElement(byInputBtnRegistro).Click();
        }
    }
}
