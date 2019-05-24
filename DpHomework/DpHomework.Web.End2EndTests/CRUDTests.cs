using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DpHomework.Web.End2EndTests
{
    [TestFixture]
    public class CRUDTests
    {
        private static string _baseURL = "http://dphomework.azurewebsites.net/main.html";
        private StringBuilder verificationErrors;


        [Test]
        public void CanLoadPage()
        {
            // Arrange
            IWebDriver driver;

            using (driver = GetWebDriver())
            {
                verificationErrors = new StringBuilder();

                // Act
                driver.Navigate().GoToUrl(_baseURL);
                driver.FindElement(By.LinkText("View Individuals")).Click();


                // Assert
                Assert.IsTrue(driver.PageSource.Contains("List of Individuals"));
                var summaryResult = driver.FindElement(By.Id("summaryText"));
                Assert.IsTrue(summaryResult.Text.CompareTo("Displaying 0 records") != 0);

                Cleanup(driver);
            }
        }

        #region Private Utility Methods
        private IWebDriver GetWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("window-size=1200,1100");
            IWebDriver driver = new ChromeDriver(chromeOptions);

            // swap constructor to toggle headless mode

            //            IWebDriver driver = new ChromeDriver();
            return driver;

        }

        private void Cleanup(IWebDriver driver)
        {
            driver.Close();
            Thread.Sleep(3500);
            driver.Quit();
        }
        #endregion  
    }
}
