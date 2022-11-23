using OpenQA.Selenium;
using PageObjectBeadandoSolution.WidgetsAtClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution.PagesAtClass
{
    public class HardveraproMainPage : BasePage
    {
        public HardveraproMainPage(IWebDriver webDriver) : base(webDriver)
        {
            
        }
        public static HardveraproMainPage Navigate(IWebDriver webDriver)
        {
            //Elnavigálunk a Hardverapró főoldalára
            webDriver.Navigate().GoToUrl("https://hardverapro.hu/index.html");
            return new HardveraproMainPage(webDriver);
        }

        public HardveraproSearchWidget GetHardveraproSearchWidget()
        {
            return new HardveraproSearchWidget(Driver);
        }// Ezzel a metódussal megszerezhetjük a kereső-widgetet
        public HardveraproResultsWidget GetHardveraproResultWidget()
        {
            return new HardveraproResultsWidget(Driver);
        } //Ezzel a metódussal megszerezhetjük az Eredmény-Widget-et
        public HardveraproMainPage CloseCookieWindows()
        {
            
            foreach (var item in Driver.FindElements(By.ClassName("close")))
            {
                item.Click();
            }
            return new HardveraproMainPage(Driver);
        }   //Ezzel a metódussal be tudjuk zárni a sütik párbeszédablakját.
    }
}
