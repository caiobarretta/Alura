using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private readonly int _millisecondsTimeout;
        private IWebElement selectWrapper;
        public IEnumerable<IWebElement> Options { get; }
        public SelectMaterialize(IWebElement element, int millisecondsTimeout = 500)
        {
            selectWrapper = element;
            _millisecondsTimeout = millisecondsTimeout;
            Options = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        private void OpenWrapper()
        {
            Thread.Sleep(_millisecondsTimeout);
            selectWrapper.Click();
        }

        private void LoseFocus()
        {
            selectWrapper
                .FindElement(By.CssSelector("li"))
                .SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();
            Options.ToList().ForEach(o =>
            {
                o.Click();
            });
            LoseFocus();
        }

        public void SelectByText(string option)
        {
            OpenWrapper();
            Options
                .Where(o => o.Text == option)
                .ToList()
                .ForEach(o => o.Click());
            LoseFocus();
        }
    }
}
