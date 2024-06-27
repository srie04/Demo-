using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpProject
{
    class LoginPage
    {
        static void Main(string[] args)
        {
            new WebDriverManager.BrowserManagers.ChromeDriverManager();

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-single-click-autofill");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddExcludedArgument("--disable-infobars");

            chromeOptions.AddArgument("--disable-build-check");
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");


            IWebDriver driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();
            Thread.Sleep(1000);
            String[] expectedProduct = { "iphone X", "Samsung Note 8" };

           var allProducts =  driver.FindElements(By.TagName("app-card"));

            foreach(var product in allProducts)
            {
                var title = product.FindElement(By.CssSelector(".card-title a"));
                Console.WriteLine(title.Text);
                if (expectedProduct.Contains(title.Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }

            driver.FindElement(By.XPath("//a[contains(text(),'Checkout')]")).Click();

         //   driver.Quit();

        }


    }
}
