using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution.PagesAtClass
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver webDriver)
        {
            Driver = webDriver;
            Driver.Manage().Timeouts().PageLoad=TimeSpan.FromSeconds(2);
            wait = new WebDriverWait(Driver,TimeSpan.FromSeconds(2));
            wait.IgnoreExceptionTypes(new Type[] { typeof(StaleElementReferenceException) });
        }

    }
}
