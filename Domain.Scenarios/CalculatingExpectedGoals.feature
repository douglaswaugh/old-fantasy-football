Feature: Strength of opponents
	In order to calculate the ease of upcoming fixtures
	As a fantasy football team manager
	I want to calculate the odds of goals being scored by the home and away teams

@nextFixture
Scenario: Getting a team's next fixture
	Given a fixture list has one games week
	And Liverpool have two fixtures in the games week
	When I get Liverpool's next fixture
	Then the first fixture should be selected

@nextFixture
Scenario: Getting a team's next fixture when a gamesweek is in progress
	Given a fixture list has two games weeks
	And the first gameweek is in progress
	When I get Wigan's next fixture
	Then the gamesweek from the second gamesweek should be selected

@nextFixture
Scenario: Getting a team's next fixture when a team has two games in same gamesweek
	Given a fixture list has two games weeks
	And Liverpool have played the fixture in the first week
	And some teams have yet to play the fixture in the first week
	Then Liverpool's next fixture should be in 