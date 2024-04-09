using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class GroomingPageTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://localhost:7174/Home/Grooming"; 

        [SetUp]
        public void Setup()
        {
            // Initialize WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ImageVisibilityTest()
        {
            // Navigate to the grooming page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the image is visible
            var image = driver.FindElement(By.CssSelector("img[src*='grooming-1']"));
            Assert.IsTrue(image.Displayed); // Assert that the image is visible
        }

        [Test]
        public void TextVisibilityTest()
        {
            // Navigate to the grooming page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the text is visible
            var paragraph = driver.FindElement(By.CssSelector(".container p"));
            Assert.IsTrue(paragraph.Displayed); // Assert that the paragraph is visible
        }

        [Test]
        public void ListVisibilityTest()
        {
            // Navigate to the grooming page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the list is visible
            var list = driver.FindElement(By.CssSelector(".container ul"));
            Assert.IsTrue(list.Displayed); // Assert that the list is visible
        }

        [Test]
        public void ButtonVisibilityTest()
        {
            // Navigate to the grooming page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the buttons are visible
            var buttons = driver.FindElements(By.CssSelector("a.btn"));
            foreach (var button in buttons)
            {
                Assert.IsTrue(button.Displayed); // Assert that each button is visible
            }
        }

        [Test]
        public void HeaderVisibilityTest()
        {
            // Navigate to the grooming page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the header is visible
            var header = driver.FindElement(By.CssSelector("h5"));
            Assert.IsTrue(header.Displayed); // Assert that the header is visible
        }

        [Test]
        public void SectionVisibilityTest()
        {
            // Navigate to the grooming page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the section is visible
            var section = driver.FindElement(By.CssSelector("section"));
            Assert.IsTrue(section.Displayed); // Assert that the section is visible
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser
            driver.Quit();
        }
    }
}
