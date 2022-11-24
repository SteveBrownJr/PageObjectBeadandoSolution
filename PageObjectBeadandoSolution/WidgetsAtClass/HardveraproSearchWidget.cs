using OpenQA.Selenium;
using PageObjectBeadandoSolution.PagesAtClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution.WidgetsAtClass
{
    public class HardveraproSearchWidget : BasePage
    {
        public IWebElement SearchDetailsArrowDown => wait.Until(D => D.FindElement(By.ClassName("fa-chevron-down")));
        //A részletes kereséshez szükséges lenyító nyilacska
        public IWebElement SearchForSpecificCounty => wait.Until(D => D.FindElements(By.ClassName("tt-input")).First(element => element.GetAttribute("placeholder") == "Szűkítés megyére"));
        //A megyére való szűrés mezője
        public IWebElement SearchBar => wait.Until(D => D.FindElements(By.ClassName("form-control")).First(element => element.GetAttribute("placeholder") == "Keresés"));
        //A keresősáv
        public IWebElement SearchForSpecificCity => wait.Until(D=>D.FindElements(By.ClassName("tt-input")).First(element => element.GetAttribute("placeholder") == "Szűkítés településre"));
        //A városra való szűrés mezője
        public IWebElement SearchForSpecificMarka => wait.Until(D => D.FindElements(By.ClassName("tt-input")).First(element => element.GetAttribute("placeholder") == "Szűrés márkára"));
        //A márkára való szűrés mezője
        public IWebElement SearchForSpecificAdvertiser => wait.Until(D => D.FindElements(By.ClassName("tt-input")).First(element => element.GetAttribute("placeholder") == "Szűrés hirdetőre"));
        //A hirdetőre való szűrés mezője
        public IWebElement SendAsPackage => wait.Until(D => D.FindElement(By.ClassName("check-indicator")));
        //A csomagküldéssel is elérhető termékek checkbox-a
        public IWebElement MinPrice => wait.Until(D => D.FindElement(By.Name("minprice")));
        //A minimális ár checkboxa
        public IWebElement MaxPrice=> wait.Until(D => D.FindElement(By.Name("maxprice")));
        //A maximális ár checkboxa
        public IWebElement SearchButton => wait.Until(D => D.FindElement(By.ClassName("fa-search")));
        //A keresőgomb
        public HardveraproSearchWidget(IWebDriver webDriver) : base(webDriver)
        {
            //Alapértelmezetten lenyitjuk a részletes keresést
            SearchDetailsArrowDown.Click();
        }
        public HardveraproSearchWidget SetSearchBar(string value)
        {
            SearchBar.SendKeys(value);
            //System.Threading.Thread.Sleep(2000);
            return new HardveraproSearchWidget(Driver);
        } //A metódus amellyel a keresőmezőbe írhatunk

        public HardveraproSearchWidget SetCounty(string County)
        {
            SearchForSpecificCity.SendKeys(County);
            return new HardveraproSearchWidget(Driver);
        } //A metódus amellyel beállíthatjuk a szűrendő megyét
        public HardveraproSearchWidget SetCity(string City)
        {
            System.Threading.Thread.Sleep(500);
            SearchForSpecificCity.SendKeys(City);
            return new HardveraproSearchWidget(Driver);
        } //A metódus amellyel beállíthatjuk a szűrendő települést
        public HardveraproCategorySearchWidget PushSearchButton()
        {
            System.Threading.Thread.Sleep(500);
            SearchButton.Click();
            return new HardveraproCategorySearchWidget(Driver);
        }   //A metódus amellyel kereshetünk
        public HardveraproSearchWidget SetMinPrice(int minprice)
        {
            MinPrice.SendKeys(minprice.ToString());
            return new HardveraproSearchWidget(Driver);
        }   //A metódus amellyel beállíthatjuk a minimum árat
        public HardveraproSearchWidget SetMaxPrice(int maxprice)
        {
            MinPrice.SendKeys(maxprice.ToString());
            return new HardveraproSearchWidget(Driver);
        }   //A metódus amellyel beállíthatjuk a maximum árat
        public HardveraproSearchWidget SetAdvertiser(string adv)
        {
            SearchForSpecificAdvertiser.SendKeys(adv);
            return new HardveraproSearchWidget(Driver);
        }   //A metódus amellyel beállíthatjuk a keresett hirdetőt
        public HardveraproSearchWidget SetBrand(string br)
        {
            SearchForSpecificMarka.SendKeys(br);
            return new HardveraproSearchWidget(Driver);
        }   //A metódus amellyel beállíthatjuk a keresett márkát
    }
}
