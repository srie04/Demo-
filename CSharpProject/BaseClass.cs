using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;

namespace CSharpProject
{
    class Base
    {
        public static IWebDriver driver;
        public void login()
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

          
            driver = new ChromeDriver(chromeOptions);
        
            driver.Manage().Window.Maximize();

            driver.Url = "https://pts.valgenesis.in/VGV4V1SP1PS/default.aspx#";

           string title =  driver.Title;
            driver.Navigate().Refresh();
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.FindElement(By.Name("txtUserName")).SendKeys("ava");
            driver.FindElement(By.Name("txtPassword")).SendKeys("valgenn");
            driver.FindElement(By.Id("btnSubmit")).Click();
            IWebElement managerPopUp = driver.FindElement(By.Id("lblCommonAlert"));
            if (managerPopUp.Displayed)
            {
                driver.FindElement(By.XPath("//a[@id='lnkCommonAlertCancel']//i[@class='fa fa-times-circle']")).Click();
            }
        }

        public void logout()
        {
            driver.FindElement(By.XPath("//span[text()='Logout']")).Click();
        }
    
    }
}
