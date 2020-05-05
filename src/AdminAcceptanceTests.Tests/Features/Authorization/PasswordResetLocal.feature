Feature: Password Reset Local
	As a User with a local account
	I want to reset my password
	So that I can access the Buying Catalogue if I have forgotten my password

Scenario: Password Reset Local - Link sent
	Given that a user wants to reset their password
	When the User has followed the request a password reset journey and entered their e-mail address
	Then the reset url is sent to the e-mail address
	And the reset url navigates to the password reset page

Scenario: Password Reset Local - Link not sent
	Given that an unknown user wants to reset their password
	When the User has followed the request a password reset journey and entered their e-mail address
	Then the reset url is not sent to the e-mail address

Scenario: Password Reset Local - Password Reset
	Given the User is resetting their password and has followed the reset url
	When the User has entered a password that meets the password policy
	Then the password is successfully set
	And the User can login with those credentials

Scenario: Password Reset Local - Does not meet Password Policy 
	Given the User is resetting their password and has followed the reset url
	When the User has entered a password that does not meets the password policy
	Then the User is informed that the Password has not been set successfully
