
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class EducationPageTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://localhost:7174/Home/Education"; 

        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void HeaderVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the header is visible
            var header = driver.FindElement(By.CssSelector("header"));
            Assert.IsTrue(header.Displayed); 
        }

        [Test]
        public void FirstImageVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the first image is visible
            var firstImage = driver.FindElement(By.CssSelector("img[src*='education-1']"));
            Assert.IsTrue(firstImage.Displayed); // Assert that the first image is visible
        }

        [Test]
        public void SecondImageVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the second image is visible
            var secondImage = driver.FindElement(By.CssSelector("img[src*='education-2']"));
            Assert.IsTrue(secondImage.Displayed); // Assert that the second image is visible
        }

        [Test]
        public void ButtonVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the buttons are visible
            var buttons = driver.FindElements(By.CssSelector(".btn"));
            foreach (var button in buttons)
            {
                Assert.IsTrue(button.Displayed); // Assert that the button is visible
            }
        }


        [Test]
        public void ListItemsVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the list items are visible
            var listItems = driver.FindElements(By.CssSelector("ul.custom li"));
            foreach (var listItem in listItems)
            {
                Assert.IsTrue(listItem.Displayed); // Assert that the list item is visible
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
