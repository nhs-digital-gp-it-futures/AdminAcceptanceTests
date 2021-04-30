Feature: Remove Proxy Relationships
	 As an Authority User,
	 I want to remove proxy relationships between organisations,
     So that nominated organisations can no longer act on behalf of other organisations

Background:
Given that an Authority User has logged in on Public Browse

Scenario: Remove Proxy Relationships - Confirmation Page
    Given that the user wants to manage the proxy relationship
    And there is a control to remove the organisation
    And the remove organisation information page is presented
    When the user clicks the remove link
    Then the user is presented with a confirmation page

Scenario: Remove Proxy Relationships - Related Organisation Removed
    Given that the user wants to manage the proxy relationship
    And there is a control to remove the organisation
    And the remove organisation information page is presented
    When the user clicks the remove link
    Then the related organisation is removed from the Organisation's information page
    And the organisation's information page is presented

Scenario: Remove Proxy Relationships - Cancel
    Given the user is on the confirmation page,
    When the user chooses to cancel
    Then the organisation's information page is presented
    #And the organisation remains in the related organisations section ##clarification needed for this

Scenario: Remove Proxy Relationships - Go Back
    Given that the user is on the organisation's information page
    When the user chooses to go back
    Then the organisation's information page is presented
    #And the organisation remains in the related organisations section
