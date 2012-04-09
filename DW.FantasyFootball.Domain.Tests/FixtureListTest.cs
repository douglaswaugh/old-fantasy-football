using System;
using System.Linq;
using Xunit;

namespace DW.FantasyFootball.Domain.Tests
{
    public class When_a_fixture_list_has_been_complied
    {
        private FixtureList _list;
        private Team _team1;
        private Team _team2;
        private Team _team3;
        private Team _team4;

        public When_a_fixture_list_has_been_complied()
        {
            _team1 = new Team("team1");

            _team2 = new Team("team2");

            _team3 = new Team("team3");

            _team4 = new Team("team4");

            var gamesweek1 = new Gamesweek();

            var gamesweek2 = new Gamesweek();

            var gamesweek3 = new Gamesweek();

            gamesweek1.AddFixture(new Fixture
                                      {
                                          AwayGoals = 1,
                                          AwayTeam = _team2,
                                          HomeGoals = 2,
                                          HomeTeam = _team1,
                                          Date = DateTime.Now.AddDays(-7),
                                          Played = true                                         
                                      });

            gamesweek1.Started = true;

            gamesweek1.Completed = true;

            gamesweek2.AddFixture(new Fixture
                                      {
                                          AwayGoals = 1,
                                          AwayTeam = _team3,
                                          HomeGoals = 2,
                                          HomeTeam = _team1,
                                          Date = DateTime.Now,
                                          Played = true
                                      });

            gamesweek2.Started = true;

            gamesweek2.Completed = true;
            
            gamesweek3.AddFixture(new Fixture
                                      {
                                          AwayGoals = 1,
                                          AwayTeam = _team3,
                                          HomeGoals = 2,
                                          HomeTeam = _team1,
                                          Date = DateTime.Now,
                                          Played = false
                                      });

            _list = new FixtureList { gamesweek1, gamesweek2, gamesweek3 };
        }

        [Fact]
        public void The_last_home_game_for_team_1_should_be_against_team_2()
        {
            Assert.Equal(_team3, _list.GetLastXHomeFixturesForTeam(_team1, 1).Single().AwayTeam);
        }

        [Fact]
        public void The_next_fixture_for_team_3_should_be_away_to_team_1()
        {
            Assert.Equal(_list.GetNextFixtures(_team3, 1).Single().HomeTeam, _team1);
        }
    }
}