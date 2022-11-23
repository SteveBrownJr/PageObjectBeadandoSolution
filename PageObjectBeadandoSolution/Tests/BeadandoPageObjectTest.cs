using NUnit.Framework;
using PageObjectBeadandoSolution.PagesAtClass;
using PageObjectBeadandoSolution.WidgetsAtClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectBeadandoSolution.Tests
{
    class BeadandoPageObjectTest : TestBase
    {
        public struct TestCaseData
        {
            public string City;
            public BlokkSize BlokkSize;
            public Order Order;
        }

        //Előre létrehozott tesztadatok Data Driven Designhoz, Sajnos Expected value csak a FilterByCityTest-nél van benne
        public TestCaseData[] PremadeTestCaseData = new TestCaseData[] {
            new TestCaseData{City="Solt",Order=Order.Cheap,BlokkSize= BlokkSize.DB25},
            new TestCaseData{City="Akasztó",Order=Order.Cheap,BlokkSize= BlokkSize.DB25},
            new TestCaseData{City="Nyíregyháza",Order=Order.Cheap,BlokkSize=BlokkSize.DB25 },
            new TestCaseData{City="Nyíregyháza",Order=Order.Cheap,BlokkSize=BlokkSize.DB100 },
            new TestCaseData{City="Miskolc",Order=Order.Cheap,BlokkSize=BlokkSize.DB100 },
            new TestCaseData{City="Százhalombatta",Order=Order.Cheap,BlokkSize=BlokkSize.DB100 },
            new TestCaseData{City="Nyíregyháza",Order=Order.Expensive,BlokkSize=BlokkSize.DB100 },
            new TestCaseData{City="Miskolc",Order=Order.Expensive,BlokkSize=BlokkSize.DB100 },
            new TestCaseData{City="Százhalombatta",Order=Order.Expensive,BlokkSize=BlokkSize.DB100 }
        };

        //Ez a teszt azt nézi meg, hogy 
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void FilterByCityTest(int i)
        {
            TestCaseData testdata = PremadeTestCaseData[i];
            foreach (Advertisment item in HardveraproMainPage.Navigate(Driver).CloseCookieWindows().GetHardveraproSearchWidget().SetCity(testdata.City).PushSearchButton().getHardveraproResultWidget().SetBlokkSizeAndOrders(testdata.BlokkSize, testdata.Order).Advertisments)
            {
                Assert.That(item.Locations.Contains(testdata.City));
            }
        }
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void SortByCheapestTest(int d)
        {
            TestCaseData testdata = PremadeTestCaseData[d];
            List<Advertisment> ads = HardveraproMainPage.Navigate(Driver).CloseCookieWindows().GetHardveraproSearchWidget().SetCity(testdata.City).PushSearchButton().getHardveraproResultWidget().SetBlokkSizeAndOrders(testdata.BlokkSize, testdata.Order).NotSponsoredAdvertisments;
            for (int i = 1; i < ads.Count; i++)
            {
                Assert.That(ads[i - 1].Price <= ads[i].Price);
            }
        }
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void SortByMostExpensiveTest(int d)
        {
            TestCaseData testdata = PremadeTestCaseData[d];
            List<Advertisment> ads = HardveraproMainPage.Navigate(Driver).CloseCookieWindows().GetHardveraproSearchWidget().SetCity(testdata.City).PushSearchButton().getHardveraproResultWidget().SetBlokkSizeAndOrders(testdata.BlokkSize, testdata.Order).NotSponsoredAdvertisments;
            for (int i = 1; i < ads.Count; i++)
            {
                Assert.That(ads[i - 1].Price >= ads[i].Price);
            }
        }
        [TestCase("Steve_Brown")]
        public void SearchForUnactiveUser(string UserName)
        {
            Assert.That(HardveraproMainPage.Navigate(Driver).CloseCookieWindows().GetHardveraproSearchWidget().SetAdvertiser(UserName).PushSearchButton().getHardveraproResultWidget().Advertisments.Count == 0);
        }
        [Test]
        public void ChangeCategory()
        {
           var q =  HardveraproMainPage.Navigate(Driver).CloseCookieWindows().GetHardveraproSearchWidget().PushSearchButton().ChangeCategory(2).getHardveraproResultWidget().Advertisments;
        }
    }
}
