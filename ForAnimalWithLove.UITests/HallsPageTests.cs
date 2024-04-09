using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    public class HallsPageTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://localhost:7174/Home/Halls";

        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void HeaderNavigationTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Replace the following with appropriate locator strategy for your navigation links
            var navLinks = driver.FindElements(By.CssSelector(".your-navigation-class"));

            foreach (var navLink in navLinks)
            {
                navLink.Click();
                Assert.IsTrue(driver.Url.Contains(navLink.Text.ToLower().Replace(" ", "-")));
            }
        }

        [Test]
        public void ImageDisplayTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Replace the following with appropriate locator strategy for your images
            var images = driver.FindElements(By.CssSelector(".your-image-class"));

            foreach (var image in images)
            {
                Assert.IsTrue(image.Displayed);
            }
        }

        [Test]
        public void TextContentTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Replace the following with appropriate locator strategy for your text content
            var textElements = driver.FindElements(By.CssSelector(".your-text-content-class"));

            foreach (var textElement in textElements)
            {
                Assert.IsFalse(string.IsNullOrEmpty(textElement.Text.Trim()));
            }
        }

        [Test]
        public void ImageAltAttributeTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            var images = driver.FindElements(By.CssSelector("img"));

            foreach (var image in images)
            {
                Assert.IsFalse(string.IsNullOrEmpty(image.GetAttribute("alt")));
            }
        }

       
        [TearDown]
        public void Teardown()
        {
            // Close the browser
            driver.Quit();
        }
    }
}
