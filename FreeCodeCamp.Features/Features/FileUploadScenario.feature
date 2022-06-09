Feature: FileUploadScenario
	File Uploading Test cases

@1001
Scenario: File Uploading Test cases
	Given User Launch the 'https://the-internet.herokuapp.com/upload' URL
	Then  Click on Choose File and Upload a New File
	And   Verify FileUploaded Successfully

Scenario: Verify User Land on herukuapp Page
	Given User Launch the 'https://the-internet.herokuapp.com/upload' URL
	Then  Verify title of the page is equal to 'The Internet' 