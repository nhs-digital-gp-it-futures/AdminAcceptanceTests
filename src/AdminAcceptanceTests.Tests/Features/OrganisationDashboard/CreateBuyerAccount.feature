Feature: Create Buyer User Account
	As an Authority User
	I want to create a User Account
	So Users can access the Buying Catalogue

Scenario: Create Buyer User Account details
	Given I am on a random organisation user account dashboard
	And account details have been provided
	When I create the buying user account
	Then the account will be associated with an organisation

Scenario: E-mail not unique
	Given I am on a random organisation user account dashboard
	And the e-mail address is not unique
	When the user attempts to add the buying user
	Then the user is informed that the e-mail address it not unique

Scenario: Mandatory fields
	Given I am on a random organisation user account dashboard
	And that mandatory data '<field>' has not been added
	When the user attempts to add the buying user
	Then the user is informed that mandatory data '<field>' is missing
	Examples: 
	   | field          |
	   | First Name     |
	   | Last Name      |
	   | E-mail Address |

@ignore
Scenario: Display name
	Given something
	When something else
	Then the display name will be the first name and last name 