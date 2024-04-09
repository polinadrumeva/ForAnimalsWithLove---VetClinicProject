
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class IndexPageTests
    {
        private IWebDriver driver;
        private string baseUrl;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(); 
            baseUrl = "https://localhost:7174/";
        }


        [Test]
        public void HeaderElementsPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of header elements
            Assert.IsTrue(ElementExists(By.CssSelector(".header-text h1")));
            Assert.IsTrue(ElementExists(By.CssSelector(".header-text p")));
            Assert.IsTrue(ElementExists(By.CssSelector(".header-text a.btn")));
        }

       
        [Test]
        public void CounterValuesTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            AssertCounterValue("Щастливи клиенти", 0); 
            AssertCounterValue("Професионалисти", 0); 
            AssertCounterValue("Осиновени", 0); 
            AssertCounterValue("Награди", 0); 
        }

        [Test]
        public void ServicesSectionPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of the services section
            Assert.IsTrue(ElementExists(By.Id("services")));
            Assert.IsTrue(ElementExists(By.CssSelector("#services .section-heading")));
            Assert.IsTrue(ElementExists(By.CssSelector("#services .container")));
            Assert.IsTrue(ElementExists(By.CssSelector("#services h2")));
        }

        [Test]
        public void BlurbSectionPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of the blurb section
            Assert.IsTrue(ElementExists(By.Id("blurb")));
            Assert.IsTrue(ElementExists(By.CssSelector("#blurb .container")));
            Assert.IsTrue(ElementExists(By.CssSelector("#blurb .row")));
            Assert.IsTrue(ElementExists(By.CssSelector("#blurb h2")));
            Assert.IsTrue(ElementExists(By.CssSelector("#blurb p")));
            Assert.IsTrue(ElementExists(By.CssSelector("#blurb a.btn")));
        }

        [Test]
        public void AboutSectionPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of the about section
            Assert.IsTrue(ElementExists(By.Id("about")));
            Assert.IsTrue(ElementExists(By.CssSelector("#about .container")));
            Assert.IsTrue(ElementExists(By.CssSelector("#about .section-heading")));
            Assert.IsTrue(ElementExists(By.CssSelector("#about h2")));
        }

        [Test]
        public void ContactSectionPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of the contact section
            Assert.IsTrue(ElementExists(By.Id("contact")));
            Assert.IsTrue(ElementExists(By.CssSelector("#contact .container")));
            Assert.IsTrue(ElementExists(By.CssSelector("#contact .row")));
            Assert.IsTrue(ElementExists(By.CssSelector("#contact h5")));
            Assert.IsTrue(ElementExists(By.CssSelector("#contact .social-media")));
        }

        [Test]
        public void FooterPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of the footer
            Assert.IsTrue(ElementExists(By.TagName("footer")));
            Assert.IsTrue(ElementExists(By.CssSelector("footer .container")));
            Assert.IsTrue(ElementExists(By.CssSelector("footer .row")));
        }


        [Test]
        public void SectionHeadingPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of section headings
            Assert.IsTrue(ElementExists(By.CssSelector("#services .section-heading h2")));
            Assert.IsTrue(ElementExists(By.CssSelector("#about .section-heading h2")));
        }

        [Test]
        public void ContactIconsPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of contact icons
            Assert.IsTrue(ElementExists(By.CssSelector("#contact .contact-icon")));
            Assert.IsTrue(ElementExists(By.CssSelector("#contact .contact-icon i")));
            Assert.IsTrue(ElementExists(By.CssSelector("#contact .contact-icon-info")));
        }

        [Test]
        public void PageTitleTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the correctness of the page title
            Assert.AreEqual("For Animals with Love", driver.Title);
        }

        // Helper method to check if an element exists
        private bool ElementExists(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Helper method to assert the presence and correctness of a navigation link
        private void AssertNavigationLink(string linkText, string expectedUrl)
        {
            var linkElement = driver.FindElement(By.LinkText(linkText));
            Assert.AreEqual(expectedUrl, linkElement.GetAttribute("href"));
        }

        // Helper method to assert the value of a counter
        private void AssertCounterValue(string counterTitle, int expectedValue)
        {
            var counterElement = driver.FindElement(By.XPath($"//h3[text()='{counterTitle}']/ancestor::div[contains(@class, 'counter')]/div[@class='counter-value']"));
            var counterValue = int.Parse(counterElement.Text);
            Assert.AreEqual(expectedValue, counterValue);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
