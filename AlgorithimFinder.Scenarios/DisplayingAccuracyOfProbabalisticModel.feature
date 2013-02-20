Feature: Displaying accuracy of probabalistic model
	In order to win at fantasy football
	As a fantasy football manager
	I want to find the best probabalistic model

Scenario: Report number of correct scores predicted
	Given team a and team b have played one game each
	And a fixture exists between team a and team b
	And the result for the fixture between team a and team b was
	When I calculate the accuracy of the probabalistic model
	Then I should be told how many correct scores were predicted 