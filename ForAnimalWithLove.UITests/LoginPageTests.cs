using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class LoginPageTests
    {
        private IWebDriver driver;
        private string baseUrl;

        [SetUp]
        public void SetUp()
        {
           driver = new ChromeDriver(); 
           baseUrl = "https://localhost:7174/Identity/Account/Login";
        }


        [Test]
        public void FormElementsPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            Assert.IsTrue(ElementExists(By.Id("account")));
            Assert.IsTrue(ElementExists(By.CssSelector("#account input[type='email']")));
            Assert.IsTrue(ElementExists(By.CssSelector("#account input[type='password']")));
            Assert.IsTrue(ElementExists(By.Id("login-submit")));
        }

        [Test]
        public void FormSubmissionTest()
        {
           driver.Navigate().GoToUrl(baseUrl);

           Assert.IsTrue(ElementExists(By.Id("login-submit")));
        }

        [Test]
        public void ValidationMessagesTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            driver.FindElement(By.Id("login-submit")).Click();

            Assert.IsTrue(ElementExists(By.CssSelector("#account .text-danger")));
            Assert.AreEqual("The Email field is required.", driver.FindElement(By.CssSelector("#account span[data-valmsg-for='Input.Email']")).Text);
            Assert.AreEqual("The Password field is required.", driver.FindElement(By.CssSelector("#account span[data-valmsg-for='Input.Password']")).Text);
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


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
