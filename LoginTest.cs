namespace HelloSeleniumTest;

using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestClass]
public class SeleniumLoginOkTest
{    
    [TestMethod]
    public void TestLoginOK()
    {
        ChromeOptions co = new();
        WebDriver driver = new ChromeDriver(co);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://instagram.com");
        Thread.Sleep(1000);
        driver.FindElement(By.XPath("//input[@name='username']")).SendKeys("roboxiv");
        driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("TRPIHOBGUPcu");
        driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        while (driver.FindElements(By.XPath("//a[@href='/direct/inbox/?next=%2F']")).Count == 0) {
            Thread.Sleep(1000);
        }
        driver.FindElement(By.XPath("//a[@href='/direct/inbox/?next=%2F']")).Click();
        Thread.Sleep(1000);
        if (driver.FindElements(By.XPath("//button[contains(text(), 'Not Now')]")).Count == 1) {
            driver.FindElement(By.XPath("//button[contains(text(), 'Not Now')]")).Click();
        }
        driver.FindElement(By.XPath("//div[@aria-label='Chats']/div/div/div/div[2]")).Click();
    }
}
