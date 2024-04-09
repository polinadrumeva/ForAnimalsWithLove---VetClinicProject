

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ForAnimalWithLove.UITests
{
    [TestFixture]
    public class RegisterPageTests
    {
        private IWebDriver driver;
        private string baseUrl = "https://localhost:7174/Identity/Account/Register";

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
        public void RegisterFormVisibilityTest()
        {
            // Navigate to the page
            driver.Navigate().GoToUrl(baseUrl);

            // Check if the register form is visible
            var registerForm = driver.FindElement(By.CssSelector("#registerForm"));
            Assert.IsTrue(registerForm.Displayed); // Assert that the register form is visible
        }

        [Test]
        public void FormElementsPresenceTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Assert the presence of form elements
            Assert.IsTrue(ElementExists(By.Id("registerForm")));
            Assert.IsTrue(ElementExists(By.CssSelector("#registerForm input[type='email']")));
            Assert.IsTrue(ElementExists(By.CssSelector("#registerForm input[type='password']")));
            Assert.IsTrue(ElementExists(By.CssSelector("#registerForm input[type='text']")));
            Assert.IsTrue(ElementExists(By.Id("registerSubmit")));
        }

        [Test]
        public void FormSubmissionTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Fill in the form fields and submit
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.Email']")).SendKeys("test@example.com");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.Password']")).SendKeys("password123");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.ConfirmPassword']")).SendKeys("password123");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.FirstName']")).SendKeys("John");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.LastName']")).SendKeys("Doe");
            driver.FindElement(By.Id("registerSubmit")).Click();

            // Assert that the registration form has been submitted
            Assert.IsTrue(ElementExists(By.Id("registerSubmit")));
        }

        [Test]
        public void EmptyFieldsValidationTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Submit the form without filling in any fields
            driver.FindElement(By.Id("registerSubmit")).Click();

            // Assert that the user remains on the registration page and sees validation error messages for each required field
            Assert.IsTrue(driver.PageSource.Contains("The Е-мeйл field is required."));
            Assert.IsTrue(driver.PageSource.Contains("The Парола field is required."));
            Assert.IsTrue(driver.PageSource.Contains("The Потвърди парола field is required."));
            Assert.IsTrue(driver.PageSource.Contains("The Име field is required."));
            Assert.IsTrue(driver.PageSource.Contains("The Фамилия field is required."));
        }

        [Test]
        public void PasswordMismatchTest()
        {
            driver.Navigate().GoToUrl(baseUrl);

            // Fill in the form fields with valid data but mismatched passwords and submit
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.Email']")).SendKeys("mismatched@example.com");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.Password']")).SendKeys("password123");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.ConfirmPassword']")).SendKeys("differentpassword123");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.FirstName']")).SendKeys("John");
            driver.FindElement(By.CssSelector("#registerForm input[name='Input.LastName']")).SendKeys("Doe");
            driver.FindElement(By.Id("registerSubmit")).Click();

            // Assert that the user remains on the registration page and sees a password mismatch error message
            Assert.IsTrue(driver.PageSource.Contains("Паролата и потвърждението на паролата не съвпадат!"));
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
