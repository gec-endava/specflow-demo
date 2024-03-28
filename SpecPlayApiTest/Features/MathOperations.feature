Feature: Math Operations

This feature tests the endpoints of the Math controller

Scenario: Addition - Happy Path
	Given the numbers 2 and 5
	When I add them using the Math API
	Then the result must be 7
