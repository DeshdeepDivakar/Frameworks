using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace demoUISpecTests.Pagemodels
{
    public class DemofwkPagefactory
    {

        private static IWebDriver _driver;
        public static GoogleAccountPage googleAccountPage;
        public static LandingPage landingPage;
        public static VerifyAccountPage verifyaccPage;
        
        public static void InitializePages(IWebDriver driver)
        {
            _driver = driver;
            googleAccountPage = new GoogleAccountPage(driver);
            landingPage = new LandingPage(driver);
            verifyaccPage = new VerifyAccountPage(driver);
        }

        public static void ResetAllPages()
        {
            googleAccountPage = null;
            landingPage = null;
            verifyaccPage = null;
        }

        public static IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
