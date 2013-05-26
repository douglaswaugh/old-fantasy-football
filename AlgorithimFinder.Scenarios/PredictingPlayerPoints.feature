Feature: PredictingPlayerPoints
	In order to beat everyone at fantasy football
	As a fantasy football manager
	I want to know which players to buy and sell

Scenario: Predict goalkeeper points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" fixture is on the "13-Nov-11"
	And "Al Habsi" has a history
	When I ask for a points prediction for "Al Habsi" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Al Habsi" will get "1.51" points

Scenario: Predict defender points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" fixture is on the "13-Nov-11"
	And the players of "Wigan" have a history
	When I ask for a points prediction for "Figueroa" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Figueroa" will get "6.83" points

Scenario: Predict midfielder points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" fixture is on the "13-Nov-11"
	And the players of "Wigan" have a history
	When I ask for a points prediction for "Maloney" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Maloney" will get "4.75" points

Scenario: Predict forward points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" fixture is on the "13-Nov-11"
	And the players of "Wigan" have a history
	When I ask for a points prediction for "Kone" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Kone" will get "8.64" points