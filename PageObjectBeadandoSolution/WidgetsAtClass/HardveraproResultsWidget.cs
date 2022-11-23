using OpenQA.Selenium;
using PageObjectBeadandoSolution.PagesAtClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution.WidgetsAtClass
{
    public struct Advertisment
    {
        public string Title;
        public int Price;
        public List<string> Locations;
    }
    public class HardveraproResultsWidget : BasePage
    {
        private List<IWebElement> FeaturedAdvertisments => Driver.FindElements(By.ClassName("featured")).ToList();
        private List<IWebElement> AdvertismentElements => Driver.FindElements(By.ClassName("media")).ToList();
        private IWebElement BlokkSizeAndOrder => Driver.FindElements(By.ClassName("dropdown-toggle"))[1];
        private List<IWebElement> BlokkSizesAndOrders { get {return Driver.FindElements(By.ClassName("dropdown-menu"))[1].FindElements(By.XPath(".//*")).Where(t=>t.Text!="Blokkméret" || t.Text!="Rendezés").ToList(); } }
        private List<List<string>> AdvertismenLocations 
        {
            get
            {
                List<List<string>> output = new List<List<string>>();
                foreach (var item in Driver.FindElements(By.ClassName("uad-info")))
                {
                    List<string> uj = new List<string>();
                    try
                    {
                        if (item.FindElement(By.ClassName("uad-light")).Text.Split(',').Last()==" ...")
                        {
                            string[] Locations = item.FindElement(By.ClassName("uad-light")).FindElement(By.XPath(".//*")).GetAttribute("data-original-title").Split(',');
                            for (int i = 0; i < Locations.Length; i++)
                            {
                                if (i < 1)
                                {
                                    uj.Add(Locations[i]);
                                }
                                else
                                {
                                    uj.Add(Locations[i].Substring(1));
                                }
                            }
                        }
                        else
                        {
                            string[] Locations = item.FindElement(By.ClassName("uad-light")).Text.Split(',');
                            for (int i = 0; i < Locations.Length; i++)
                            {
                                if (i < 1)
                                {
                                    uj.Add(Locations[i]);
                                }
                                else
                                {
                                    uj.Add(Locations[i].Substring(1));
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                            output.Add(uj);
                    }

                }
                return output;
            } 
        }
        public List<string> AdvertismentTitles => Driver.FindElements(By.ClassName("uad-title")).Select(t=>t.Text).ToList();
        public List<int> AdvertismentPrices => Driver.FindElements(By.ClassName("uad-price")).Select(t => SetStringPriceToInteger(t.Text)).ToList();
        public List<bool> AdvertismentIsSponsored => Driver.FindElements(By.ClassName("uad-ultralight")).Select(t => t.FindElement(By.XPath(".//*")).Text == "Előresorolt hirdetés").ToList();

        public List<Advertisment> NotSponsoredAdvertisments 
        {
            get
            {
                List<Advertisment> sposoredAdverisments = new List<Advertisment>();
                List<string> advertismentTitles = AdvertismentTitles;
                List<bool> advertismentIsSponsored = AdvertismentIsSponsored;
                List<int> advertismentPrices = AdvertismentPrices;
                List<List<string>> advertismentLocations = AdvertismenLocations;

                if (advertismentTitles.Count == advertismentIsSponsored.Count && advertismentIsSponsored.Count == advertismentPrices.Count && advertismentPrices.Count == advertismentLocations.Count)
                {
                    for (int i = 0; i < advertismentTitles.Count; i++)
                    {
                        if (!advertismentIsSponsored[i])
                        {
                            sposoredAdverisments.Add(new Advertisment()
                            {
                                Price = advertismentPrices[i],
                                Title = advertismentTitles[i],
                                Locations = advertismentLocations[i]
                            });
                        }
                    }
                }

                return sposoredAdverisments;
            }
        }
        public List<Advertisment> Advertisments 
        { 
            get 
            {
                List<Advertisment> sposoredAdverisments=new List<Advertisment>();
                List<string> advertismentTitles = AdvertismentTitles;
                List<bool> advertismentIsSponsored = AdvertismentIsSponsored;
                List<int> advertismentPrices = AdvertismentPrices;
                List<List<string>> advertismentLocations = AdvertismenLocations;
                
                if (advertismentTitles.Count== advertismentIsSponsored.Count && advertismentIsSponsored.Count == advertismentPrices.Count && advertismentPrices.Count == advertismentLocations.Count)
                {
                    for (int i = 0; i < advertismentTitles.Count; i++)
                    {
                        if (true)
                        {
                            sposoredAdverisments.Add(new Advertisment()
                            {
                                Price = advertismentPrices[i],
                                Title = advertismentTitles[i],
                                Locations= advertismentLocations[i]
                            });
                        }
                    }
                }

                return sposoredAdverisments;
            } 
        }
        public List<Advertisment> SponsoredAdvertisments 
        {
            get
            {
                List<Advertisment> sposoredAdverisments = new List<Advertisment>();
                List<string> advertismentTitles = AdvertismentTitles;
                List<bool> advertismentIsSponsored = AdvertismentIsSponsored;
                List<int> advertismentPrices = AdvertismentPrices;
                List<List<string>> advertismentLocations = AdvertismenLocations;

                if (advertismentTitles.Count == advertismentIsSponsored.Count && advertismentIsSponsored.Count == advertismentPrices.Count && advertismentPrices.Count == advertismentLocations.Count)
                {
                    for (int i = 0; i < advertismentTitles.Count; i++)
                    {
                        if (advertismentIsSponsored[i])
                        {
                            sposoredAdverisments.Add(new Advertisment()
                            {
                                Price = advertismentPrices[i],
                                Title = advertismentTitles[i],
                                Locations = advertismentLocations[i]
                            });
                        }
                    }
                }

                return sposoredAdverisments;
            }
        }

        public HardveraproResultsWidget(IWebDriver webDriver) : base(webDriver)
        {
        }

        private int SetStringPriceToInteger(string stringPrice)
        {
            string moderatedPrice = "";
            for (int i = 0; i < stringPrice.Length-3; i++)
            {
                if (stringPrice[i]=='0' ||
                    stringPrice[i]=='1' ||
                    stringPrice[i]=='2' ||
                    stringPrice[i]=='3' ||
                    stringPrice[i]=='4' ||
                    stringPrice[i]=='5' ||
                    stringPrice[i]=='6' ||
                    stringPrice[i]=='7' ||
                    stringPrice[i]=='8' ||
                    stringPrice[i]=='9'
                    )
                {
                    moderatedPrice += stringPrice[i];
                }
            }
            try
            {
                return int.Parse(moderatedPrice);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public HardveraproResultsWidget SetBlokkSizeAndOrders(BlokkSize blokkSize,Order order)
        {
            switch (blokkSize)
            {
                case BlokkSize.DB25:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[1].Click();
                    break;
                case BlokkSize.DB50:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[2].Click();
                    break;
                case BlokkSize.DB100:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[3].Click();
                    break;
                case BlokkSize.DB200:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[4].Click();
                    break;
            }
            System.Threading.Thread.Sleep(2000);
            switch (order)
            {
                case Order.NewAdvertisments:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[6].Click();
                    break;
                case Order.Refreshed:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[7].Click();
                    break;
                case Order.Cheap:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[8].Click();
                    break;
                case Order.Expensive:
                    BlokkSizeAndOrder.Click();
                    BlokkSizesAndOrders[9].Click();
                    break;
            }
            System.Threading.Thread.Sleep(2000);
            return new HardveraproResultsWidget(Driver);
        }
    }
    public enum BlokkSize
    {
        DB25,
        DB50,
        DB100,
        DB200
    }
    public enum Order
    {
        NewAdvertisments,
        Refreshed,
        Cheap,
        Expensive
    }
}
