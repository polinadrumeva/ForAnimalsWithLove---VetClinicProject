using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class AboutPageTests
{
	private IWebDriver driver;
	private string baseUrl = "https://localhost:7174"; // Update port as necessary

	[SetUp]
	public void Setup()
	{
		driver = new ChromeDriver();
		driver.Manage().Window.Maximize();
	}

	[TearDown]
	public void Teardown()
	{
		driver.Quit();
	}

	[Test]
	public void TestAboutPageTitle()
	{
		// Navigate to the About page
		driver.Navigate().GoToUrl(baseUrl + "/Home/About");

		// Get the page title
		string pageTitle = driver.Title;

		// Assert that the page title contains the expected text
		Assert.IsTrue(pageTitle.Contains("About"), "About page title does not contain expected text");
	}
}