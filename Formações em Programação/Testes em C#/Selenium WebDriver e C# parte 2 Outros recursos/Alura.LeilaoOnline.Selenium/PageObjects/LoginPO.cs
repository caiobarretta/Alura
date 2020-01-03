using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private const string Url = "http://localhost:5000/Autenticacao/Login";

        private readonly IWebDriver _driver;

        private By byInputLogin;
        private By byInputPassword;
        private By byInputBtnLogin;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;

            byInputLogin = By.Id("Login");
            byInputPassword = By.Id("Password");
            byInputBtnLogin = By.Id("btnLogin");
        }

        public LoginPO PreencheFormulario(string login, string password) => InformarEmail(login).InformaSenha(password);

        public LoginPO InformarEmail(string login)
        {
            _driver.FindElement(byInputLogin).SendKeys(login);//Login
            return this;
        }

        public LoginPO InformaSenha(string password)
        {
            _driver.FindElement(byInputPassword).SendKeys(password);//Password
            return this;
        }

        public LoginPO NavigateGoToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
            return this;

        }

        public LoginPO SubmitForm()
        {
            _driver.FindElement(byInputBtnLogin).Submit();
            return this;

        }

        public void EfetuarLoginComCredenciais(string login, string password)
        {
            NavigateGoToUrl()
            .PreencheFormulario(login, password)
            .SubmitForm();
        }

    }
}
