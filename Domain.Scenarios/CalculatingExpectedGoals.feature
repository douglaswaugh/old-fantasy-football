Feature: Strength of opponents
	In order to calculate the ease of upcoming fixtures
	As a fantasy football team manager
	I want to calculate the odds of goals being scored by the home and away teams

@nextFixture
Scenario: Getting a team's next fixture when a team has two games in one games week
	Given a fixture list has one games week
	And Liverpool have two fixtures in the games week
	When I get Liverpool's next fixture
	Then the first fixture should be selected

@nextFixture
Scenario: Getting a team's next fixture when a gamesweek is in progress
	Given a fixture list has two games weeks
	And the first gameweek is in progress
	When I get Wigan's next fixture
	Then Wigan's fixture from the second games week should be selected

@nextFixture
Scenario: Getting a team's last home fixture when they did not play in all games weeks
	Given a fixture list has two games weeks
	And Sunderland did not play in the first games week
	And All the games have been played
	When I get Sunderland's last home fixture
	Then Sunderland's fixture from the second games week should be selected

@nextFixture
Scenario: Getting a team's next fixture when there is more than one games week to play
	Given a fixture list has two games weeks
	When I get Sunderland's next fixture
	Then Sunderland's fixture from the first games week should be selected

@nextFixture
Scenario: Getting a team's last home fixture when there are more games to play
	Given a fixture list has two games weeks
	And The first games week has been completed
	When I get Arsenal's last home fixture
	Then Arsenal's fixture from the first games week should be selected