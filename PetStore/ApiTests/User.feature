Feature: Users
User management

@tag1
Scenario: User creation
	Given a new user account is created with the following properties
		| username | firstName | lastName | email          | password | phone       |
		| liz      | Lizzie    | Bishop   | lizzie@test.nl | 123456   | 06-90909090 |
	When the account details are requested
	Then the entered details are returned
