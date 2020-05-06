Feature: Accept Agreement
	As a User logging in without an accepted End User Agreement
	I want to be provided with the Agreement and decide whether to accept it
	So that I can choose to accept the conditions to use the Buying Catalogue

Scenario: Agreement not accepted
	Given that a User has not accepted the Agreement
	When the User has logged in
	Then the User is presented with the Agreement for using the Buying Catalogue

Scenario: Agreement accepted
	Given that a User is presented with the Agreement
	When the User indicates they will accept the Agreement
	And the User chooses to continue past the Agreement
	Then the User can continue their Journey past the Agreement
	And it is recorded that the Agreement is signed by the User

Scenario: Agreement not signed 
	Given that a User is presented with the Agreement
	When the User does not indicate that they will accept the Agreement
	And the User chooses to continue past the Agreement
	Then the User can not continue their Journey past the Agreement
	And the User is informed why they cannot continue
	And there is no record that the Agreement was signed
@ignore
Scenario: Accept Agreement - Returning User Already Agreed
	Given that a User has accepted the agreement
	When the User has logged in
	Then the User is not presented with the agreement 