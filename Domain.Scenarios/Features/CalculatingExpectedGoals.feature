Feature: Strength of opponents
	In order to calculate the ease of upcoming fixtures
	As a fantasy football team manager
	I want to calculate the odds of goals being scored by the home and away teams

@nextFixture
Scenario: Getting a team's next fixture when a gamesweek is in progress
	Given a fixture list has two gamesweeks
	And the first gamesweek is in progress
	When I get Wigan's next fixture from the next gamesweek
	Then Wigan's fixture from the second gamesweek should be selected

@nextFixture
Scenario: Getting a team's last home fixture when they did not play in all gamesweeks
	Given a fixture list has two gamesweeks
	And Sunderland did not play in the first gamesweek
	And all the games have been played
	When I get Sunderland's last home fixture
	Then Sunderland's fixture from the second gamesweek should be selected

@nextFixture
Scenario: Getting a team's next fixture when there is more than one gamesweek to play
	Given a fixture list has two gamesweeks
	When I get Sunderland's next fixture
	Then Sunderland's fixture from the first gamesweek should be selected

@nextFixture
Scenario: Getting a team's last home fixture when there are more games to play
	Given a fixture list has two gamesweeks
	And the first gamesweek has been completed
	When I get Arsenal's last home fixture
	Then Arsenal's fixture from the first gamesweek should be selected

@nextFixture
Scenario: Getting a team's last 2 home fixtures
	Given a fixture list has two gamesweeks
	And all the games have been played
	When I get Arsenal's last two home fixtures
	Then Arsenal's fixture from the first gamesweek should be selected
	And Arsenal's fixture from the second gamesweek should be selected
	And two fixtures should be selected

@nextFixture
Scenario: Getting a team's next two fixtures when they don't have a fixture in the second gamesweek
	Given a fixture list has three gamesweeks
	And Wigan do not have a fixture in the second gamesweek
	When I get Wigan's next two fixtures
	Then Wigan's fixture from the first gamesweek should be returned
	And Wigan's fixture from the third gamesweek should be returned
	And two fixtures should be returned

@nextFixture
Scenario: Getting a team's fixtures for a double gamesweek
	Given a fixture list has one gamesweek
	And Stoke have two fixtures in the gamesweek
	When I get Stoke's fixtures for the gamesweek
	Then two fixtures should be returned
	And Stoke's first fixture from the gamesweek should be returned
	And Stoke's second fixture from the second gamesweek should be returned