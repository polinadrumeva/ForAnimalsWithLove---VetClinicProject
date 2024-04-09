using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class ContactPageTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://localhost:7174/Home/Contact";

        [SetUp]
        public void Setup()
        {
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
            Assert.IsTrue(header.Displayed); // Assert that the header is visible
        }

        [Test]
        public void FooterVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the footer is visible
            var footer = driver.FindElement(By.CssSelector("footer"));
            Assert.IsTrue(footer.Displayed); // Assert that the footer is visible
        }

        [Test]
        public void ContactInfoVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the contact information is visible
            var contactInfo = driver.FindElement(By.CssSelector(".contact-info"));
            Assert.IsTrue(contactInfo.Displayed); // Assert that the contact information is visible
        }

        [Test]
        public void ContactInfoContentTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the contact information content is correct
            var contactInfo = driver.FindElement(By.CssSelector(".contact-info"));

            // Verify email
            var emailElement = contactInfo.FindElement(By.CssSelector("li:nth-child(1)"));
            Assert.IsTrue(emailElement.Text.Contains("office@foranimalswithlove.bg")); // Assert that the email is correct

            // Verify phone number
            var phoneElement = contactInfo.FindElement(By.CssSelector("li:nth-child(2)"));
            Assert.IsTrue(phoneElement.Text.Contains("0700 12 323")); // Assert that the phone number is correct

            // Verify address
            var addressElement = contactInfo.FindElement(By.CssSelector("li:nth-child(3)"));
            Assert.IsTrue(addressElement.Text.Contains("Pet Street 123 - София")); // Assert that the address is correct
        }

        [Test]
        public void MapVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the map is visible
            var map = driver.FindElement(By.CssSelector("iframe[src*='google.com/maps']"));
            Assert.IsTrue(map.Displayed); // Assert that the map is visible
        }

        [TearDown]
        public void Teardown()
        {
            // Close the browser
            driver.Quit();
        }
    }
}
