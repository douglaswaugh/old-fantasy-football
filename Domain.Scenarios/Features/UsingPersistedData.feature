Feature: Using Persisted Data
	In order to speed up development
	As a developer
	I want to be able to use data previously scrapped from the site

Scenario: Loading data from one gamesweek
	Given that one data from one gamesweek has been scrapped and saved
	When I calculate the strength of fixtures 
	And I select option to 
	Then a team should have the best defensive fixtures