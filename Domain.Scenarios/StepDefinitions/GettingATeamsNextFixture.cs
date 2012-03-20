using System;
using DW.FantasyFootball.Domain;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;
using TechTalk.SpecFlow;

namespace Dw.FantasyFootball.Domain.Scenarios.StepDefinitions
{
    [Binding]
    public class GettingATeamsNextFixture
    {
        private FixtureList _fixtureList;

        private Team _astonVilla = new Team("Aston Villa");

        private Team _fulham = new Team("Fulham");

        private Team _chelsea = new Team("Chelsea");

        private Team _stokeCity = new Team("Stoke City");

        private Team _sunderland = new Team("Sunderland");

        private Team _liverpool = new Team("Liverpool");

        private Team _wolves = new Team("Wolves");

        private Team _blackburn = new Team("Blackburn");

        private Team _everton = new Team("Everton");

        private Team _tottenham = new Team("Tottenham");

        private Team _manUtd = new Team("Man Utd");

        private Team _westBrom = new Team("West Brom");

        private Team _swansea = new Team("Swansea");

        private Team _manCity = new Team("Man City");

        private Team _norwich = new Team("Norwich");

        private Team _wigan = new Team("Wigan");

        private Team _arsenal = new Team("Arsenal");

        private Team _newcastle = new Team("Newcastle");

        private Gamesweek _gamesweek;
        private Fixture _nextFixture;
        private Fixture _firstFixture;
        private Team _bolton = new Team("Bolton");
        private Team _qpr = new Team("QPR");
        private Gamesweek _gamesweek1;
        private Fixture _wigansNextFixture;
        private Fixture _wigansSecondFixture;

        [Given(@"a fixture list has one games week")]
        public void GivenAFixtureListHasOneGamesWeek()
        {
            _gamesweek = new Gamesweek();

            _firstFixture = new Fixture { HomeTeam = _sunderland, AwayTeam = _liverpool, Date = new DateTime(2012, 3, 10) };

            _gamesweek.AddFixture(new Fixture { HomeTeam = _astonVilla, AwayTeam = _fulham, Date = new DateTime(2012, 3, 10) });
            _gamesweek.AddFixture(new Fixture { HomeTeam = _chelsea, AwayTeam = _stokeCity, Date = new DateTime(2012, 3, 10) });
            _gamesweek.AddFixture(_firstFixture);
            _gamesweek.AddFixture(new Fixture { HomeTeam = _wolves, AwayTeam = _blackburn, Date = new DateTime(2012, 3, 10) });
            _gamesweek.AddFixture(new Fixture { HomeTeam = _everton, AwayTeam = _tottenham, Date = new DateTime(2012, 3, 10) });
            _gamesweek.AddFixture(new Fixture { HomeTeam = _manUtd, AwayTeam = _westBrom, Date = new DateTime(2012, 3, 11) });
            _gamesweek.AddFixture(new Fixture { HomeTeam = _swansea, AwayTeam = _manCity, Date = new DateTime(2012, 3, 11) });
            _gamesweek.AddFixture(new Fixture { HomeTeam = _norwich, AwayTeam = _wigan, Date = new DateTime(2012, 3, 11) });
            _gamesweek.AddFixture(new Fixture { HomeTeam = _arsenal, AwayTeam = _newcastle, Date = new DateTime(2012, 3, 12) });

            _fixtureList = new FixtureList { _gamesweek };
        }

        [Given(@"Liverpool have two fixtures in the games week")]
        public void GivenLiverpoolHaveTwoFixturesInTheGamesWeek()
        {
            _gamesweek.AddFixture(new Fixture { HomeTeam = _liverpool, AwayTeam = _everton, Date = new DateTime(2012, 3, 13) });
        }

        [When(@"I get Liverpool's next fixture")]
        public void WhenIGetLiverpoolSNextFixture()
        {
            var logger = MockRepository.GenerateMock<ILog>();

            _nextFixture = _fixtureList.GetNextGamesweeksFixture(_liverpool, logger);
        }

        [Then(@"the first fixture should be selected")]
        public void ThenTheFirstFixtureShouldBeSelected()
        {
            Assert.That(_nextFixture, Is.EqualTo(_firstFixture));
        }


        [Given(@"a fixture list has two games weeks")]
        public void GivenAFixtureListHasTwoGamesWeeks()
        {
            _gamesweek1 = new Gamesweek();

            var _wiganFirstFixture = new Fixture
                                         {HomeTeam = _wigan, AwayTeam = _swansea, Date = new DateTime(2012, 2, 25)};

            _gamesweek1.AddFixture(new Fixture { HomeTeam = _blackburn, AwayTeam = _astonVilla, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _manCity, AwayTeam = _bolton, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _qpr, AwayTeam = _everton, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _stokeCity, AwayTeam = _norwich, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _westBrom, AwayTeam = _chelsea, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(_wiganFirstFixture);
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _newcastle, AwayTeam = _sunderland, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _fulham, AwayTeam = _wolves, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _tottenham, AwayTeam = _manUtd, Date = new DateTime(2012, 2, 25) });

            var _gamesweek2 = new Gamesweek();

            _firstFixture = new Fixture { HomeTeam = _sunderland, AwayTeam = _liverpool, Date = new DateTime(2012, 3, 10) };

            _wigansSecondFixture = new Fixture
                                      {HomeTeam = _norwich, AwayTeam = _wigan, Date = new DateTime(2012, 3, 11)};

            _gamesweek2.AddFixture(new Fixture { HomeTeam = _astonVilla, AwayTeam = _fulham, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _chelsea, AwayTeam = _stokeCity, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(_firstFixture);
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _wolves, AwayTeam = _blackburn, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _everton, AwayTeam = _tottenham, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _manUtd, AwayTeam = _westBrom, Date = new DateTime(2012, 3, 11) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _swansea, AwayTeam = _manCity, Date = new DateTime(2012, 3, 11) });
            _gamesweek2.AddFixture(_wigansSecondFixture);
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _arsenal, AwayTeam = _newcastle, Date = new DateTime(2012, 3, 12) });
            
            _fixtureList = new FixtureList { _gamesweek1, _gamesweek2 };
        }

        [Given(@"the first gameweek is in progress")]
        public void GivenTheFirstGameweekIsInProgress()
        {
            int i = 0;
            foreach(var fixture in _gamesweek1)
            {
                fixture.Played = true;
                i++;
                if (i >= 5) { break; }
            }

            _gamesweek1.Started = true;
        }

        [When(@"I get Wigan's next fixture")]
        public void WhenIGetWiganSNextFixture()
        {
            var logger = MockRepository.GenerateStub<ILog>();

            _wigansNextFixture = _fixtureList.GetNextGamesweeksFixture(_wigan, logger);
        }

        [Then(@"the gamesweek from the second gamesweek should be selected")]
        public void ThenTheGamesweekFromTheSecondGamesweekShouldBeSelected()
        {
            Assert.That(_wigansNextFixture, Is.EqualTo(_wigansSecondFixture));
        }

        [Given(@"Liverpool have played the fixture in the first week")]
        public void GivenLiverpoolHavePlayedTheFixtureInTheFirstWeek()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"some teams have yet to play the fixture in the first week")]
        public void GivenSomeTeamsHaveYetToPlayTheFixtureInTheFirstWeek()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Liverpool's next fixture should be in")]
        public void ThenLiverpoolSNextFixtureShouldBeIn()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
