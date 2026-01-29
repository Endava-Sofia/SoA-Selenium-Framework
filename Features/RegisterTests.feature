Feature: RegisterTests

A short summary of the feature

@tag1
Scenario: Verify user is able to register successfully
	Given I register new user with valid details
	And I login with the created user
	When [action]
	Then [outcome]
