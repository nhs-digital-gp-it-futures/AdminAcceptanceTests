Feature: Buyer Organisation Creation
	As an Authority User
	I want to create a Buyer Organisation in the Buying Catalogue
	So that the Organisation exists on the Buying Catalogue

Background: 
Given the Authority User is managing organisations and users
@ignore
Scenario: Buyer Organisation Creation - Buyer Organisation created
	Given a Buyer Organisation does not already exist in the Buying Catalogue
	When the Organisation is being created
	Then the Organisation exists in the Buying Catalogue
	And the Primary Role ID from ODS identifies the Organisation as a Buyer Organisation

Scenario: Buyer Organisation Creation - Non-Buyer Organisation Returned
	Given that a User enters an ODS code for a non-Buyer Organisation
	When the Organisation is searched for
	Then a validation error message will be returned

Scenario: Buyer Organisation Creation - unrecognised code
	Given that the User enters a code unrecognised by ODS
	When the Organisation is searched for
	Then a validation error message will be returned

@ignore
Scenario: Buyer Organisation Creation - Organisation already exists
	Given a Buyer Organisation already exists in the Buying Catalogue
	When the user attempts to crate the Organisation
	Then a validation error message will be returned