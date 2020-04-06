Feature: View User Details
	As an Authority User
	I want to view a User Account
	So that I can see details about the account and manage it

Scenario: View User Details
Given that a User elects to view a buying user's details 
When they select to view a user's details from the organisation's user accounts dashboard
Then the User can view the details
And the details include Name
And Name will be concatenation of the First Name and Last Name
And the details include Contact Details
And the details include E-mail Address
And the details include Organisation Name
