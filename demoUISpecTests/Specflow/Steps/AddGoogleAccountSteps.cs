using Xunit;
using TechTalk.SpecFlow;
using demoUISpecTests.DataStructure;
using demoUISpecTests.Pagemodels;
using RelevantCodes.ExtentReports;
using System.Configuration;

namespace demoUISpecTests.Specflow.Steps
{
    [Binding]
    public sealed class AddGoogleAccountSteps
    {
        public static ExtentReports exRepo = new ExtentReports(ConfigurationManager.AppSettings["Reports"].ToString());
        ExtentTest logs = exRepo.StartTest(ScenarioContext.Current.ScenarioInfo.Tags[0].ToString() + "-" + ScenarioContext.Current.ScenarioInfo.Title.ToString());

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I have to add an account for a new user")]
        public void GivenIHaveToAddAnAccountForANewUser()
        {
            
        }


        [When(@"I complete the form (.*) (.*)")]
        public void WhenICompleteTheFormJonPoddrick(string fisrtname, string lastname, Table table)
        {
            logs.AssignCategory("AddGoogleAccount-UI-Spec-Test");
            logs.AssignAuthor(ConfigurationManager.AppSettings["Author"].ToString());

            foreach (var row in table.Rows)
            {
                Formdata data = new Formdata()
                {
                    FirstName = fisrtname,
                    LastName = lastname,
                    UserName = row["UserName"],
                    NewPwd = row["NewPwd"],
                    ConfirmPwd = row["ConfirmPwd"],
                    Dob = row["Dob"],
                    Gender = row["Gender"],
                    Country = row["Country"],
                    Number = row["Number"],
                    RecoveryEmail = row["RecoveryEmail"],
                    Location = row["Location"]
                };

                DemofwkPagefactory.landingPage.createAcc();
                logs.Log(LogStatus.Pass, "Create Account Clicked successfully.");
                exRepo.EndTest(logs);

                DemofwkPagefactory.googleAccountPage.fillDetails(data);
                logs.Log(LogStatus.Pass, "Data filled successfully.");
                exRepo.EndTest(logs);

                DemofwkPagefactory.verifyaccPage.contButton();
                logs.Log(LogStatus.Pass, "Clicked Continue successfully.");
                exRepo.EndTest(logs);
            }
        }


        [Then(@"the user should be on the code verification page")]
        public void ThenTheUserShouldBeOnTheCodeVerificationPage()
        {
            Assert.Equal("Verify your account", DemofwkPagefactory.verifyaccPage.getText());
            logs.Log(LogStatus.Pass, "Successfully on Verify account page.");
            exRepo.EndTest(logs);
            exRepo.Flush();
        }


    }
}
