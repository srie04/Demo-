using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

using System.Threading;

namespace CSharpProject
{
    class input
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

            driver.Manage().Window.Maximize();

            driver.Url = "https://www.google.com/";
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.TextEntry("A");
            Thread.Sleep(2000);
            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.DOWN);
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.DOWN);

            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RETURN);
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RETURN);

        }
    }
}
