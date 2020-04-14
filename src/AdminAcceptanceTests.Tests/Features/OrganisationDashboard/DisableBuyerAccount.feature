Feature: Disable Buyer Account
	As an Authority User
	I want to disable a User Account
	So that the User's credentials can no longer be used to access the Buying Catalogue
@ignore
Scenario: Disable Buyer Account
	Given a buyer account is currently enabled
	When the authority user disables the buyer account
	Then the account listed on the user accounts dashboard shows as disabled
	And the buyer user cannot login

Scenario: Enable Buyer Account
	Given a buyer account is currently disabled
	When the authority user enables the buyer account
	Then the account listed on the user accounts dashboard does not show as disabled
	And the buyer user can login
