using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using demoframework;
using demoframework.Utilities;
using System;
using demoUISpecTests.DataStructure;
using OpenQA.Selenium.Interactions;

namespace demoUISpecTests.Pagemodels
{
    public class GoogleAccountPage : BasePage
    {
        public GoogleAccountPage(IWebDriver webdriver):base(webdriver)
        {
            PageFactory.InitElements(webdriver, this);
        }


        [FindsBy(How = How.XPath, Using = "//div[@class='form-element multi-field name']//label[@id='firstname-label']//Input[@id='FirstName']")]
        public IWebElement FirstName;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element multi-field name']//label[@id='lastname-label']//Input[@id='LastName']")]
        public IWebElement LastName;

        [FindsBy(How=How.XPath,Using = "//div[@class='form-element email-address']//label[@id='gmail-address-label']//Input[@id='GmailAddress']")]
        public IWebElement UserName;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element']//label[@id='password-label']//Input[@id='Passwd']")]
        public IWebElement CreatePwd;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element']//label[@id='confirm-password-label']//Input[@id='PasswdAgain']")]
        public IWebElement ConfirmPwd;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element multi-field birthday']//div[@class='goog-inline-block goog-flat-menu-button-dropdown']")]
        public IWebElement BirthMonthParentSelector;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element multi-field birthday']//label[@id='day-label']//Input[@id='BirthDay']")]
        public IWebElement Day;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element multi-field birthday']//label[@id='year-label']//Input[@id='BirthYear']")]
        public IWebElement Year;

        [FindsBy(How = How.XPath, Using = "//div[@id='gender-form-element']//label[@id='gender-label']//div[@id='Gender']//div[@class='goog-inline-block goog-flat-menu-button jfk-select']")]
        public IWebElement GenderParentSelector;

        [FindsBy(How = How.XPath, Using = "//div[@id='gender-form-element']//label[@id='gender-label']//div[@id='Gender']//div[@class='goog-menu goog-menu-vertical']//div[@class='goog-menuitem']")]
        public IWebElement Genderselect;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element']//table[@class='i18n_phone_number_input i18n_phone_number_input-empty']//div[@class='goog-inline-block i18n-phone-select-country-dropdown']")]
        public IWebElement Country;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element']//table[@class='i18n_phone_number_input i18n_phone_number_input-empty']//tr//td//Input[@id='RecoveryPhoneNumber']")]
        public IWebElement Number;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element recovery-email']//label[@id='recovery-email-label']//input")]
        public IWebElement Recoveryemail;

        [FindsBy(How = How.XPath, Using = "//div[@id='CountryCode']//div[@class='goog-inline-block goog-flat-menu-button-dropdown']")]
        public IWebElement Location;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-element email-address']//div[@id='username-errormsg-and-suggestions']//span")]
        public IWebElement UsernameTaken;


        [FindsBy(How = How.XPath, Using = "//div[@class='form-element nextstep-button']//Input[@id='submitbutton']")]
        public IWebElement NextButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='tos-button-div']//Input[@id='iagreebutton']")]
        public IWebElement IagreeButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='tos-scroll']")]
        public IWebElement scroll;

        public void fillDetails(Formdata data)
        {
            string uname;
            FirstName.SendKeys(data.FirstName);
            LastName.SendKeys(data.LastName);
            UserName.SendKeys(data.UserName);

            UserName.SendKeys(Keys.Tab);

            while(Initialiser.WaitforElementDisplayed(UsernameTaken) == true)
            {
                Random rnd = new Random();
                UserName.Clear();
                uname = RandomString.GenerateRandomString(7, rnd);
                UserName.SendKeys(data.UserName + uname);
                UserName.SendKeys(Keys.Tab);
            }

            CreatePwd.SendKeys(data.NewPwd);
            ConfirmPwd.SendKeys(data.ConfirmPwd);


            BirthMonthParentSelector.Click();
            string[] birthdetails= data.Dob.Split('-');
            BirthMonthParentSelector.FindElement(By.XPath("//div[@class='goog-menu goog-menu-vertical']//div[contains(text(),'" + birthdetails[0] + "')]")).Click();

            Day.SendKeys(birthdetails[1]);
            Year.SendKeys(birthdetails[2]);

            GenderParentSelector.Click();
            Genderselect.FindElement(By.XPath("//div[contains(text(),'" + data.Gender + "')]")).Click();

            Number.SendKeys(data.Number);
            Recoveryemail.SendKeys(data.RecoveryEmail);
            NextButton.Click();

            //Initialiser.ScrollElementIntoView(scroll);            

            while (!Initialiser.WaitForElementEnabled(IagreeButton))
            {
                scroll.SendKeys(Keys.Down);
            }
            IagreeButton.Click();
        }
    }
}
