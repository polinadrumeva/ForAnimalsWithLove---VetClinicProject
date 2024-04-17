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
		public void TestLoginFormDisplayedCorrectly()
		{
			driver.Navigate().GoToUrl(baseUrl);

			// Assert that the login form is displayed correctly
			Assert.IsTrue(driver.FindElement(By.TagName("h2")).Text.Contains("Вход"));
			Assert.IsTrue(driver.FindElement(By.CssSelector("form#account")).Displayed);
			Assert.IsTrue(driver.FindElement(By.CssSelector("input[name='Input.Email']")).Displayed);
			Assert.IsTrue(driver.FindElement(By.CssSelector("input[name='Input.Password']")).Displayed);
			Assert.IsTrue(driver.FindElement(By.CssSelector("button#login-submit")).Displayed);
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
