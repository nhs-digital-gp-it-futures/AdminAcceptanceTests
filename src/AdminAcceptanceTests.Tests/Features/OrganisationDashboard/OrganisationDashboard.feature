Feature: Organisations Dashboard
	As an Authority User 
	I want to add new Organisations or undertake other activities related to existing Organisations
	So that I can manage Organisations and their Users

Scenario: Tile on Public Browse Homepage
	Given that an Authority User has logged in on Public Browse
	Then there is an additional tile for the Authority User to access the dashboard

Scenario: Organisations Dashboard
	Given that an Authority User has logged in on Public Browse
	When an Authority User clicks the admin tile on the Public Browse homepage
	Then the Authority User is directed to the Organisations Dashboard
	And the User can add an Organisation 
	And the User can select an Organisation
