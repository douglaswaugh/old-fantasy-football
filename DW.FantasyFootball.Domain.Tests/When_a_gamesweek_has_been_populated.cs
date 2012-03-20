using System;
using Xunit;

namespace DW.FantasyFootball.Domain.Tests
{
    public class When_a_gamesweek_has_been_populated
    {
        private Team _team1;
        private Team _team2;
        private Team _team3;
        private Team _team4;
        private Team _team5;
        private Gamesweek _gamesweek1;

        public When_a_gamesweek_has_been_populated()
        {
            _team1 = new Team("team1");

            _team2 = new Team("team2");

            _team3 = new Team("team3");

            _team4 = new Team("team4");
            
            _team5 = new Team("team5");

            _gamesweek1 = new Gamesweek();

            _gamesweek1.AddFixture(new Fixture
                                      {
                                          AwayGoals = 1,
                                          AwayTeam = _team2,
                                          HomeGoals = 2,
                                          HomeTeam = _team1,
                                          Date = DateTime.Now.AddDays(-7),
                                          Played = true
                                      });

            _gamesweek1.AddFixture(new Fixture
                                       {
                                           AwayGoals = 1,
                                           AwayTeam = _team2,
                                           HomeGoals = 2,
                                           HomeTeam = _team4,
                                           Date = DateTime.Now.AddDays(0),
                                           Played = false
                                       });

            _gamesweek1.AddFixture(new Fixture
                                        {
                                            AwayGoals = 1,
                                            AwayTeam = _team2,
                                            HomeGoals = 2,
                                            HomeTeam = _team5,
                                            Date = DateTime.Now.AddDays(3),
                                            Played = false 
                                        });
            
        }

        [Fact]
        public void Then_a_team_with_a_fixture_should_have_game()
        {
            Assert.True(_gamesweek1.HasGame(_team1));
        }

        [Fact]
        public void Then_a_team_without_a_fixture_should_not_have_a_game()
        {
            Assert.False(_gamesweek1.HasGame(_team3));
        }

        [Fact]
        public void Then_a_team_with_two_fixtures_should_play_earliest_unplayed_game_first()
        {
            Assert.Equal(_team4, _gamesweek1.GetNextFixtureForTeam(_team2).HomeTeam);
        }
    }
}
