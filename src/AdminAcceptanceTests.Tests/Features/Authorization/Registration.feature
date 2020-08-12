@SmokeTest
Feature: Registration
	As a Public User
	I want to register for an account
	So that I can login to the Buying Catalogue

Scenario: Registration - Request account link
	Given that a User is not logged in
	Then a link to request an account is displayed

Scenario: Registration - Request an account page
	Given that a User is not logged in
	When the User clicks the request an account link on the login page
	Then the request an account page is displayed
	And the request an account button has the expected mailto

