using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demoUISpecTests.Pagemodels
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver webdriver):base(webdriver)
        {
            PageFactory.InitElements(webdriver, this);
        }

        [FindsBy(How=How.XPath,Using = "//div[@class='card-mask']/div[@class='one-google']/p//span//a[contains(.,'Create account')]")]
        public IWebElement createAccount;       



        public void createAcc()
        {
            createAccount.Click();
        }

    }
}
