Feature: Create Buyer User Account
	As an Authority User
	I want to create a User Account
	So Users can access the Buying Catalogue

Scenario: Create Buyer User Account details
	Given I am on a random organisation user account dashboard
	And account details have been provided
	When I create the buying user account
	Then the account will be associated with an organisation

Scenario: Create Buyer User Account - Display name
	Given I am on a random organisation user account dashboard
	And account details have been provided
	When I create the buying user account
	Then the display name will be the first name and last name on the account creation confirmation screen

Scenario: Create Buyer User Account - E-mail not unique
	Given I am on a random organisation user account dashboard
	And the e-mail address is not unique
	When the user attempts to add the buying user
	Then the user is informed that the e-mail address it not unique

Scenario: Create Buyer User Account - Mandatory fields
	Given I am on a random organisation user account dashboard
	And that mandatory data '<field>' has not been added
	When the user attempts to add the buying user
	Then the user is informed that mandatory data '<field>' is missing
	Examples: 
	   | field          |
	   | First Name     |
	   | Last Name      |
	   | E-mail Address |
	   | Phone Number   |

Scenario: Create Buyer User Account - Email too long
	Given I am on a random organisation user account dashboard
	And I enter too long an email address
	When the user attempts to add the buying user
	Then the user is informed that the email address is too long

Scenario: Create Buyer User Account - First name too long
	Given I am on a random organisation user account dashboard
	And I enter too long a first name
	When the user attempts to add the buying user
	Then the user is informed that the first name is too long

Scenario: Create Buyer User Account - Last name too long
	Given I am on a random organisation user account dashboard
	And I enter too long a last name
	When the user attempts to add the buying user
	Then the user is informed that the last name is too long

Scenario: Create Buyer User Account - Phone Number too long
	Given I am on a random organisation user account dashboard
	And I enter too long a phone number
	When the user attempts to add the buying user
	Then the user is informed that the phone number is too long

Scenario: Create Buyer User Account - Email invalid format
	Given I am on a random organisation user account dashboard
	And I enter an invalid email address format
	When the user attempts to add the buying user
	Then the user is informed that the email address is in an invalid format