Feature: Displaying accuracy of probabalistic model
	In order to win at fantasy football
	As a fantasy football manager
	I want to find the best probabalistic model

Scenario: Display number of correct scores
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" result on the "13-Nov-11" was 3 1
	When I ask for a prediction for matches after "13-Nov-11"
	Then I should be told 0 correct scores were predicted

@Ignore
Scenario: Display percentage of correct scores

@Ignore
Scenario: Display standard deviation of goals scored

@Ignore
Scenario: Display standard deviation of goals conceded

Scenario: Predict fixture from all past results
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Southampton" result on the "6-Nov-11" was 3 1
	And the "Southampton" "Wigan" result on the "13-Nov-11" was 4 2
	When I ask for a prediction for matches after "13-Nov-11"
	Then I should be told 0 correct scores were predicted

Scenario: Predict next two fixtures from all past results
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Southampton" result on the "6-Nov-11" was 3 1
	And the "Southampton" "Wigan" result on the "13-Nov-11" was 4 2
	And the "Wolves" "Wigan" result on the "20-Nov-2011" was 3 0
	When I ask for a prediction for matches after "13-Nov-11"
	Then I should be told 0 correct scores were predicted

Scenario: Display number of correct scores after correct prediction
	Given the "Wigan" "Wolves" result on the "13-Oct-11" was 3 2
	And the "Wolves" "Wigan" result on the "20-Nov-11" was 1 2
	When I ask for a prediction for matches after "20-nov-11"
	Then I should be told 1 correct scores were predicted

Scenario: Predict fixture form last six results
	Given seven weeks fixtures have been played
	When I ask for a prediction for matches after "13-May-12"
	Then I should be told 1 correct scores were predicted

@Ignore
Scenario: Predict fixture from this season's results

@Ignore
Scenario: Predict fixture from last year's results

@Ignore
Scenario: Predict home fixture from last six home results