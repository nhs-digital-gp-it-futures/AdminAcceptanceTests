﻿Feature: Create Buyer User Account
	As an Authority User
	I want to create a User Account
	So Users can access the Buying Catalogue

Scenario: Create Buyer User Account details
	Given I am on a random organisation user account dashboard
	And account details have been provided
	When I create the buying user account
	Then the account will be associated with an organisation
	And the display name will be the first name and last name 
	And the permission set is inherited from the organisation type

Scenario: E-mail not unique
	Given I am on a random organisation user account dashboard
	And the e-mail address is not unique
	When the User has entered an e-mail address
	And attempted to add the User
	Then the User is informed that the e-mail address it not unique

Scenario: Mandatory fields
	Given I am on a random organisation user account dashboard
	And that mandatory data '<field>' has not been added
	When the User attempted to add the User
	Then the User is informed that mandatory data is missing
	Examples: 
	   | field          |
	   | First Name     |
	   | Last Name      |
	   | E-mail Address |