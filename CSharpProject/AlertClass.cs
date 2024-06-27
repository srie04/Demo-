using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProject
{
    class AlertClass
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Execution Started");

            new WebDriverManager.BrowserManagers.ChromeDriverManager();

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-single-click-autofill");
            chromeOptions.AddArgument("--disable-popup-blocking");
            chromeOptions.AddExcludedArgument("--disable-infobars");

            chromeOptions.AddArgument("--disable-build-check");
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");


            IWebDriver driver = new ChromeDriver(chromeOptions);

            driver.Manage().Window.Maximize();

            driver.Url = "https://demoqa.com/alerts";

            driver.FindElement(By.Id("confirmButton")).Click();

            System.Threading.Thread.Sleep(2000);
            string text =   driver.SwitchTo().Alert().Text;
            Console.WriteLine(text);
            driver.SwitchTo().Alert().Dismiss();
        }
    }
}
