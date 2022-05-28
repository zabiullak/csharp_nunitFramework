Feature: SikuliActions
	Use Sikuli to work with UI Web

@1000 @sikuli
Scenario: Check the Sikuli Click Action is working fine

	Given User Launch the 'https://opensource-demo.orangehrmlive.com/index.php/auth/login' URL
	And   Enter UN as 'Admin' and PWD as 'admin123'
	Then  Click on Login using Sikuli Actions