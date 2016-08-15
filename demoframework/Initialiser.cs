using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Drawing.Imaging;

namespace demoframework
{
    public static class Initialiser
    {
        private static IWebDriver _driver;

        public static IWebDriver getDriver(string browserName, int timeout=3)
        {
            switch (browserName)
            {
                case "IE":
                    _driver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    string path = ConfigurationManager.AppSettings["SeleniumDriverPath"];
                    _driver = new ChromeDriver(path);
                    break;
            }
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
            return _driver;
        }

        public static void Open(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public static bool WaitforElementDisplayed(IWebElement element, int timeOut = 10)
        {
            var isDisplayed = true;
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(x => element.Displayed);
            }
            catch(Exception ex)
            {
                isDisplayed = false;
                Console.Write($"Exception while waiting for element : {ex.Message}");
            }
            return isDisplayed;
        }

        public static void Maximize()
        {
            _driver.Manage().Window.Maximize();
        }

        public static void ScrollElementIntoView(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);
        }

        public static bool WaitForElementEnabled(IWebElement element, int timeOut = 5)
        {
            var isEnabled = true;
            try
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(x => element.Enabled);
            }
            catch (Exception ex)
            {
                isEnabled = false;
                Console.WriteLine("Exception while waiting for webelement " + ex);
            }
            return isEnabled;
        }

        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Close();
            }
        }


        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
        }

        public static void TakeScreenshot(String fileName, String directory, bool takeScreenshot = true)
        {
            try
            {
                if (takeScreenshot)
                {
                    var dateString = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
                    directory = directory.Replace("DATE", dateString);
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    var fileFullPath = directory + Path.DirectorySeparatorChar + fileName;
                    Screenshot screenShot = ((ITakesScreenshot)_driver).GetScreenshot();
                    screenShot.SaveAsFile(fileFullPath, ImageFormat.Png);
                    Console.Write("Screenshot Saved\n" + fileFullPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }

    }
}
