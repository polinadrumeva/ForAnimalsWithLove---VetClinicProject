

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class HotelsPageTests
    {
        private IWebDriver driver;
        private string baseUrl;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(); 
            baseUrl = "https://localhost:7174/Home/Hotels";
        }


        [Test]
        public void HeaderTextTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            var headingText = driver.FindElement(By.CssSelector(".section-heading h3")).Text;

            Assert.AreEqual("Forest Hotel", headingText.Trim());
        }


        [Test]
        public void TextContentTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            var paragraphs = driver.FindElements(By.CssSelector("p"));

            foreach (var paragraph in paragraphs)
            {
                Assert.IsFalse(string.IsNullOrEmpty(paragraph.Text.Trim()));
            }
        }

        [Test]
        public void HotelNameAndLocationTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            var hotelName = driver.FindElement(By.CssSelector(".section-heading h3")).Text;
            var hotelLocation = driver.FindElement(By.CssSelector(".section-heading h5")).Text;

            Assert.AreEqual("Forest Hotel", hotelName.Trim());
            Assert.AreEqual("гр. Банско", hotelLocation.Trim());
        }

        [Test]
        public void PriceListTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            var priceListItems = driver.FindElements(By.CssSelector("ul.custom li"));

            foreach (var priceListItem in priceListItems)
            {
                Assert.IsFalse(string.IsNullOrEmpty(priceListItem.Text.Trim()));
            }
        }

        [Test]
        public void ImageAltAttributeTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            var images = driver.FindElements(By.CssSelector("img"));

            foreach (var image in images)
            {
                var altAttribute = image.GetAttribute("alt");
                Assert.IsFalse(string.IsNullOrEmpty(altAttribute));
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
