Feature: Define Proxy Organisation Relationships
    As an Authority User,
    I want to define the Proxy relationships between organisations
    So that nominated organisations can act on behalf of Customer Organisations

Background:
    Given that an Authority User has logged in on Public Browse

Scenario: Define Proxy Organisation Relationships - Viewing Existing Proxy Organisations
    Given that the user wants to define a new proxy relationship
    When an organisation is selected
    Then the organisation's information page is presented
    And the related ODS code is presented
    And there is a control to add a new related organisation

Scenario: Define Proxy Organisation Relationships - Choosing Related Organisations
    Given that the user wants to define a new proxy relationship
    When an organisation is selected
    Then the user can see a list of all available organisations in the Buying Catalogue
    And the list of organisations is presented in alphabetical order

Scenario: Define Proxy Organisation Relationships - Error Message
    Given that the user is on the user account dashboard
    And there is a control to confirm
    And no organisation is selected
    When the user chooses to confirm
    Then the user is presented with an error message
    And the user is informed they have to select an organisation

Scenario: Define Proxy Organisation Relationships - Saving Proxy Relationships
    Given that the user is on the user account dashboard
    When the user selects an organisation
    And the user chooses to confirm a new related organisation
    Then the organisation is included in the related organisation section on the Organisation's information page 
    And there is a control to remove the organisation

Scenario: Define Proxy Organisation Relationships - Go Back
    Given that the user is on the user account dashboard
    When the user chooses to go back
    Then the user is taken back to the Organisation's information page
