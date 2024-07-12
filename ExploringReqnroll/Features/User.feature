Feature: Users
As an administrator
I want to be able to create users
So they can login

Scenario: Valid user creation
	Given a new user account is created with the following properties
		| username | firstName | lastName | email          | password | phone       |
		| liz      | Lizzie    | Bishop   | lizzie@test.nl | 123456   | 06-90909090 |
	When the account details are requested
	Then the account details match
	And an id has been assigned

Scenario: Invalid user creation
	Given a new user account is created with the following properties
		| username | firstName | lastName | email          | password | phone       |
		|          |  Dizzie   | Bishop   | dizzie@test.nl | 666666   | 06-10101010 |
	When the account details are requested
	Then nothing is returned

