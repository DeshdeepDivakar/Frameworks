using System;
using demoframework;
using TechTalk.SpecFlow;
using System.Configuration;
using demoUISpecTests.Pagemodels;

namespace demoUISpecTests
{
    [Binding]
    public class BeforeAfterSteps
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            var browserName = ConfigurationManager.AppSettings["browserName"];
            var applicationUrl = ConfigurationManager.AppSettings["browserUrl"];
            DemofwkPagefactory.InitializePages(Initialiser.getDriver(browserName));

            Initialiser.Maximize();
            Initialiser.Open(applicationUrl);

        }


        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                var takeScreenshot = Boolean.Parse(ConfigurationManager.AppSettings["takeScrenshot"]);
                var fileName = ScenarioContext.Current.ScenarioInfo.Title + "_" + DateTime.Now.ToString("dd_MM_yyyyThh_mm_ss") + ".png";
                fileName = fileName.Replace(":", "_").Replace(" ", "_");
                var screenshotfolder = ConfigurationManager.AppSettings["screenshotfolder"];
                Initialiser.TakeScreenshot(fileName, screenshotfolder, takeScreenshot);
            }

            Initialiser.CloseDriver();
            Initialiser.QuitDriver();
            DemofwkPagefactory.ResetAllPages();
        }

    }
}
