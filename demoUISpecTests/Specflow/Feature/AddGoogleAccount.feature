@Add Account Test
Feature: AddGoogleAccount
	
@TC#1
Scenario Outline: Add new Google account for a user
	Given I have to add an account for a new user
	When I complete the form <FirstName> <LastName>
	| UserName    | NewPwd     | ConfirmPwd | Dob               | Gender | Country   | Number     | RecoveryEmail | Location  |
	| jPodrrick99 | Toyota@235 | Toyota@235 | September-23-1981 | Male   | Australia | 0450700125 | abc@gmail.com | Australia |
	Then the user should be on the code verification page
Examples: 
| FirstName | LastName |
| Jon       | Poddrick |