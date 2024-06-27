using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using WindowsInput;
using OpenQA.Selenium.Interactions;

namespace CSharpProject
{
    class SubashTask : Base
    {
        static void Main(string[] args){
            SubashTask task = new SubashTask();
            task.login();
            driver.FindElement(By.XPath("//a[text()='Execution']")).Click();
            driver.FindElement(By.XPath("//p[text()='Initiate and assign execution for executable documents from Development, Project, and CCR']")).Click();
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='framecontent']")));

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='btnInitiateExecution']")).Click();

            Thread.Sleep(1000);
           
            IWebElement selectEntity = driver.FindElement(By.XPath("//table//td[@class='dxic']"));
            selectEntity.Click();

            InputSimulator sim = new InputSimulator();
            
            sim.Keyboard.TextEntry("Endoscope Execution");
        
            Thread.Sleep(1000); ;
            driver.FindElement(By.XPath("//td[contains(@dxtext,'Endoscope Execution')]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//span[@id='select2-ddlValidationType-container']")).Click();

            sim.Keyboard.TextEntry("Operational Qualification");
            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RETURN);
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RETURN);

            driver.FindElement(By.XPath("//span[@id='select2-ddlMappingList-container']")).Click();
            Thread.Sleep(1000);
            sim.Keyboard.TextEntry("OQ-Endo-Exe-0001.01");
            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RETURN);
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RETURN);

            driver.FindElement(By.XPath("//label[text()='Yes']")).Click();
            driver.FindElement(By.Name("btnSubmit")).Click();
            Thread.Sleep(3000);
            String processName =  driver.FindElement(By.XPath("//div[@id='val1_pnlConfirmationMessage']//span[contains(text(),'been Initiated')]")).Text;
            Console.WriteLine(processName);
            //input[@id='btnMessageOk']
            driver.FindElement(By.XPath("//input[@id='btnMessageOk']")).Click();

            Thread.Sleep(2000);

            //   driver.SwitchTo().Frame("//iframe[@id='framecontent']");
            driver.FindElement(By.Id("txtBoxTargetDate_input")).Clear();
            driver.FindElement(By.Id("txtBoxTargetDate_input")).SendKeys("24-01-2024");

            //driver.FindElement(By.Id("txtBoxTargetDate_input")).Click();

            ////     action.MoveByOffset(835, 737).Click().Perform();

            //Thread.Sleep(2000);
            //driver.FindElement(By.XPath("//table//td[text()='23']")).Click();

            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//span[@id='select2-ddWorkFlow-container']")).Click();
            Thread.Sleep(1000);
            sim.Keyboard.TextEntry("Ventilator Workflow");
            Thread.Sleep(1000);
            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RETURN);
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RETURN);
            Thread.Sleep(1000);
            driver.FindElement(By.Name("btnSubmit")).Click();

            
        }
    }
}
