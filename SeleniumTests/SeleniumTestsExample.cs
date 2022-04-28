using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    public class SeleniumTestsExample
    {
        IWebDriver? driver;

        [SetUp]
        public void startBrowser()
        {
            // TODO: Place here path to you chrome driver
            driver = new ChromeDriver("C:\\Skola\\SoftwareQuality");
        }

        [Test]
        public void OrderProcessTest()
        {
            driver.Url = "https://www.saucedemo.com";

            driver.FindElement(By.Name("user-name")).SendKeys("standard_user");
            driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
            driver.FindElement(By.Name("login-button")).Submit();

            driver.FindElement(By.Name("add-to-cart-sauce-labs-backpack")).Click();
            Assert.AreEqual("1", driver.FindElement(By.ClassName("shopping_cart_link")).Text);
            driver.FindElement(By.Name("add-to-cart-sauce-labs-bike-light")).Click();
            Assert.AreEqual("2", driver.FindElement(By.ClassName("shopping_cart_link")).Text);
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            Assert.AreEqual(2, driver.FindElements(By.ClassName("inventory_item_name")).Count);
            Assert.AreEqual("Sauce Labs Backpack", driver.FindElements(By.ClassName("inventory_item_name"))[0].Text);
            Assert.AreEqual("Sauce Labs Bike Light", driver.FindElements(By.ClassName("inventory_item_name"))[1].Text);
            driver.FindElement(By.Name("checkout")).Click();
            driver.FindElement(By.Name("firstName")).SendKeys("Karolina");
            driver.FindElement(By.Name("lastName")).SendKeys("Vsela");
            driver.FindElement(By.Name("postalCode")).SendKeys("62500");
            driver.FindElement(By.Name("continue")).Click();
            Assert.AreEqual("FREE PONY EXPRESS DELIVERY!",driver.FindElements(By.ClassName("summary_value_label"))[1].Text);
            driver.FindElement(By.Name("finish")).Click();
            Assert.AreEqual("THANK YOU FOR YOUR ORDER",driver.FindElement(By.ClassName("complete-header")).Text);

        }

        [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }
    }

}