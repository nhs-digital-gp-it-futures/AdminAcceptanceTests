Feature: Login Local
	As a Registered User
	I want to login to the Buying Catalogue without using an external authentication tool
	So that I can do Buying Catalogue Activities 

Scenario: Login
	Given that a User is not logged in
	When a User provides recognised authentication details to login locally
	Then the User will be logged in

Scenario Outline: Login with incorrect credentials
	Given that a User is not logged in
	When a User provides a <Username> username
	And a User provides a <Password> password
	Then the User will not be logged in
	And the User will be informed the login attempt was unsuccessful Email <Username>, password <Password>

	Examples:
	| Username | Password |
	| true     | false    |
	| false    | true     |
	| false    | false    |

Scenario: Log out
	Given the User is logged in
	When the User logs out
	Then the User is logged out