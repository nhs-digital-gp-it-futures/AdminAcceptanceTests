@SmokeTest
Feature: Organisation's User Accounts Dashboard
	As an Authority User
	I want to edit Organisation accounts, add new Users and manage existing User
	So that I can manage access to the Buying Catalogue

Background:
	Given that an Authority User has logged in on Public Browse
	And an Authority User clicks the admin tile on the Public Browse homepage

Scenario: User Accounts Dashboard - User Accounts Dashboard Displayed
	When an organisation is selected
	Then the User Accounts Dashboard for that organisation is displayed

Scenario: User Accounts Dashboard - Edit organisation Account Detail
	When an organisation is selected
	Then there is a button the to edit the Organisation's Account details

Scenario: User Accounts Dashboard - Add new User
	When an organisation is selected
	Then there is a button to start off the Create User Account journey

@ignore 
#Need to be able to add users to be able to test this
Scenario: User Accounts Dashboard - Manage User Account
	When an organisation is selected
	Then there is a link to edit the User's Account details