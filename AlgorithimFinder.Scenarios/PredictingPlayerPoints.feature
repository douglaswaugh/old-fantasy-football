Feature: PredictingPlayerPoints
	In order to beat everyone at fantasy football
	As a fantasy football manager
	I want to know which players to buy and sell

Scenario: Predict goalkeeper points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" result on the "13-Nov-11" was 3 1
	And "Al Habsi" has the history
	| Round | Opponent   | Minutes | GoalsScored | Assists | CleanSheets | GoalsConceded | OwnGoals | PenaltiesSaved | PenaltiesMissed | YellowCards | RedCards | Saves | Bonus | Points |
	| 1     | CHE(H) 0-2 | 90      | 0           | 0       | 0           | 2             | 0        | 0              | 0               | 0           | 0        | 1     | 0     | 1      |
	| 2     | SOU(A) 2-0 | 90      | 0           | 0       | 1           | 0             | 0        | 0              | 0               | 0           | 0        | 6     | 2     | 10     |
	| 3     | STK(H) 2-2 | 90      | 0           | 0       | 0           | 2             | 0        | 0              | 0               | 0           | 0        | 5     | 0     | 2      |
	| 4     | MUN(A) 0-4 | 90      | 0           | 0       | 0           | 4             | 0        | 1              | 0               | 0           | 0        | 0     | 0     | 5      |
	| 5     | FUL(H) 1-2 | 90      | 0           | 0       | 0           | 2             | 0        | 0              | 0               | 0           | 0        | 6     | 0     | 3      |
	When I ask for a points prediction for "Al Habsi" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Al Habsi" will get "1.51" points

Scenario: Predict defender points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" result on the "13-Nov-11" was 3 1
	And the players of "Wigan" have a history
	When I ask for a points prediction for "Figueroa" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Figueroa" will get "7.23" points

Scenario: Predict midfielder points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" result on the "13-Nov-11" was 3 1
	And the players of "Wigan" have a history
	When I ask for a points prediction for "Maloney" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Maloney" will get "4.95" points

Scenario: Predict forward points
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" result on the "13-Nov-11" was 3 1
	And the players of "Wigan" have a history
	When I ask for a points prediction for "Kone" of "Wigan" for matches after "13-Nov-11"
	Then I should be told "Kone" will get "9.24" points