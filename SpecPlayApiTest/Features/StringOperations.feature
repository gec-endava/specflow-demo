Feature: StringOperations

This feature is testing the String Operations of the SpecPlay API

Scenario Outline: Counting characters
	Given the string "<inputString>"
	When I invoke Count Chars method
	Then I get response code <expectedResponseCode>
	And I get <expectedCount> in response

Examples:
| inputString | expectedResponseCode | expectedCount |
| abcdef      | 200                  | 6             |
| Hello world | 200                  | 11            |
| 0123456789  | 200                  | 10            |

