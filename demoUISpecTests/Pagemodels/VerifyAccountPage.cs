using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demoUISpecTests.Pagemodels
{
    public class VerifyAccountPage :BasePage
    {
        public VerifyAccountPage(IWebDriver webdriver):base(webdriver)
        {
            PageFactory.InitElements(webdriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='submit-buttons']//Input[@id='next-button']")]
        public IWebElement continueButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='main content clearfix']/h1[@class='redtext']")]
        public IWebElement verifyText;

        public void contButton()
        {
            continueButton.Click();
        }
        
        public string getText()
        {
            return verifyText.Text.ToString();
        }

    }
}
