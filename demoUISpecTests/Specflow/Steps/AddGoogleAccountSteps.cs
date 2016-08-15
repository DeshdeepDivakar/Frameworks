using Xunit;
using TechTalk.SpecFlow;
using demoUISpecTests.DataStructure;
using demoUISpecTests.Pagemodels;

namespace demoUISpecTests.Specflow.Steps
{
    [Binding]
    public sealed class AddGoogleAccountSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I have to add an account for a new user")]
        public void GivenIHaveToAddAnAccountForANewUser()
        {
            
        }


        [When(@"I complete the form (.*) (.*)")]
        public void WhenICompleteTheFormJonPoddrick(string fisrtname, string lastname, Table table)
        {
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
                DemofwkPagefactory.googleAccountPage.fillDetails(data);
                DemofwkPagefactory.verifyaccPage.contButton();
            }
        }


        [Then(@"the user should be on the code verification page")]
        public void ThenTheUserShouldBeOnTheCodeVerificationPage()
        {
            Assert.Equal("Verify your account", DemofwkPagefactory.verifyaccPage.getText());
            
        }


    }
}
