@ignore
Feature: PasswordResetLocal
	As a User with a local account
	I want to reset my password
	So that I can access the Buying Catalogue if I have forgotten my password

Scenario: Link sent
Given that a user wants to reset their password
When the User followed the request a password reset journey and entered their e-mail address
Then the reset url is sent to the e-mail address
And the reset url navigates to the password reset page

Scenario: Link not sent
Given that an unknown user wants to reset their password
When the User followed the request a password reset journey and entered their e-mail address
Then the reset url is not sent to the e-mail address

Scenario: Password Reset
Given the User is resetting their password and has followed the reset url
When the User has entered a password that meets the password policy
Then the password is successfully set
And the User can login with those credentials

Scenario: Does not meet Password Policy 
Given the User is resetting their password and has followed the reset url
When the User has entered a password that does not meets the password policy
Then the User is informed that the Password has not been set successfully
