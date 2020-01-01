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

        public void PreencheFormulario(string login, string password)
        {
            _driver.FindElement(byInputLogin).SendKeys(login);//Login
            _driver.FindElement(byInputPassword).SendKeys(password);//Password
        }

        public void NavigateGoToUrl()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void SubmitForm()
        {
            _driver.FindElement(byInputBtnLogin).Submit();
        }

    }
}
