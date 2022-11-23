using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution
{
    [TestFixture]
    class TestBase
    {
        IWebDriver driver;

        public IWebDriver Driver
        {
            get
            { return driver; }
            set
            {
                driver.Quit();
                driver = value;
            }
        }

        [SetUp]
        protected void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=hu");

            driver = new ChromeDriver(options);
        }

        [TearDown]
        protected void Teardown()
        {
            driver.Quit();
        }
    }
}
