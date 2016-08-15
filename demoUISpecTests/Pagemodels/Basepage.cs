using OpenQA.Selenium;
using demoframework;

namespace demoUISpecTests.Pagemodels
{
    public class BasePage
    {
        public IWebDriver driver;
        public BasePage(IWebDriver webdriver)
        {
            driver = webdriver;      
        }

        public void Open(string url)
        {
            Initialiser.Open(url);
        }
    }
}
