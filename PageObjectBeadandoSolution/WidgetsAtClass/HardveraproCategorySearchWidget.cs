using OpenQA.Selenium;
using PageObjectBeadandoSolution.PagesAtClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution.WidgetsAtClass
{
    public class HardveraproCategorySearchWidget : BasePage
    {
        public List<string> Categories
        {
            get
            {
                List<string> Categoriak = Driver.FindElements(By.ClassName("uad-categories-item")).Select(t => t.FindElement(By.XPath(".//*")).Text).ToList();
                return Categoriak;
            }
        }
        public HardveraproCategorySearchWidget(IWebDriver webDriver) : base(webDriver)
        {

        }
        public HardveraproCategorySearchWidget ChangeCategory(int dest)
        {
            System.Threading.Thread.Sleep(500);
            Driver.FindElements(By.ClassName("uad-categories-item")).Select(t => t.FindElement(By.XPath(".//*"))).ToArray()[dest].Click();
            return new HardveraproCategorySearchWidget(Driver);
        }
        public HardveraproResultsWidget getHardveraproResultWidget()
        {
            return new HardveraproResultsWidget(Driver);
        }
    }
}
