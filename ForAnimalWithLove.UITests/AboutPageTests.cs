using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class AboutPageTests
{
	private IWebDriver driver;
	private string baseUrl = "https://localhost:7174/Home/About"; 

	[SetUp]
	public void Setup()
	{
		driver = new ChromeDriver();
		driver.Manage().Window.Maximize();
	}


    [Test]
    public void ResponsiveDesignTest()
    {
        // Navigate to the page
        driver.Navigate().GoToUrl(baseUrl);

        // Test responsiveness by resizing the window
        driver.Manage().Window.Size = new System.Drawing.Size(375, 667); // Example size of iPhone 6/7/8
                                                                         

        driver.Manage().Window.Size = new System.Drawing.Size(1024, 768); // Example size of tablet
                                                                         
    }

    [Test]
    public void ImageLoadingTest()
    {
        // Navigate to the page
        driver.Navigate().GoToUrl(baseUrl);

        // Check if images are loaded correctly
        var images = driver.FindElements(By.CssSelector("img"));
        foreach (var image in images)
        {
            Assert.IsTrue(image.Displayed);
        }
    }

    [Test]
    public void ImageAltAttributesTest()
    {
        // Navigate to the page
        driver.Navigate().GoToUrl(baseUrl);

        // Check if all images have alt attributes
        var images = driver.FindElements(By.CssSelector("img"));
        foreach (var image in images)
        {
            Assert.IsFalse(string.IsNullOrEmpty(image.GetAttribute("alt"))); // Assert that alt attribute is not empty
        }
    }


    [Test]
    public void HeaderFooterVisibilityTest()
    {
        // Navigate to the page
        driver.Navigate().GoToUrl(baseUrl);

        // Check if the header and footer are visible
        var header = driver.FindElement(By.CssSelector("header"));
        Assert.IsTrue(header.Displayed); 

        var footer = driver.FindElement(By.CssSelector("footer"));
        Assert.IsTrue(footer.Displayed); 
    }

    [Test]
    public void ListItemsTest()
    {
        // Navigate to the page
        driver.Navigate().GoToUrl(baseUrl);

        // Check if all list items are present
        var listItems = driver.FindElements(By.CssSelector("ul.custom li"));
        Assert.AreEqual(7, listItems.Count);
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
    }

}