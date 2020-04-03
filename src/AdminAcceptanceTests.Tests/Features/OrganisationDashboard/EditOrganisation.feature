Feature: Edit Organisation
	As an Authority User
	I want to edit an Organisation's Account
	So that I can change an Organisation's End User Agreement

Scenario: Edit Organisation End User Agreement
	Given that an authority user is editing an organisation's account details
	When an authority user edits the end user agreement
	Then the organisation's end user agreement status is updated
	And an authority user resets the end user agreement
