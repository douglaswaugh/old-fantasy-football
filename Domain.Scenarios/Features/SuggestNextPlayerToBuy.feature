Feature: Suggest Next Player To Buy
	In order to win the fantasy football game
	As a fantasy football manager
	I want to know what the best transfer is

Scenario: Stronger goalkeeper available
	Given one gamesweek has been played
	And one gamesweek has yet to be played
	And I have selected a team
	When I calculate the best transfer
	Then my worst goalkeeper should be suggested to transfer out
	And the best goalkeeper should be suggested to transfer in

#Scenario: Stronger goalkeeper not available