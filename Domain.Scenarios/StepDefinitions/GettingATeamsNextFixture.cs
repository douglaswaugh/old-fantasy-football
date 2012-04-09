using System;
using System.Collections.Generic;
using System.Linq;
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

        private Team _bolton = new Team("Bolton");

        private Team _qpr = new Team("QPR");

        private Gamesweek _gamesweek1;
        private Gamesweek _gamesweek2;
        private Gamesweek _gamesweek3;
        private Fixture _sunderlandsLastHomeFixture;
        private Fixture _sunderlandsNextFixture;
        private Fixture _arsenalsLastHomeFixture;
        private Fixture _arsenalsSecondLastHomeFixture;
        private Fixture _returnedFixture;
        private IEnumerable<Fixture> _returnedFixtures;

        [Given(@"a fixture list has one gamesweek")]
        public void GivenAFixtureListHasOneGamesWeek()
        {
            _gamesweek1 = new Gamesweek();

            _gamesweek1.AddFixture(new Fixture { HomeTeam = _blackburn, AwayTeam = _astonVilla, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _manCity, AwayTeam = _bolton, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _qpr, AwayTeam = _everton, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _stokeCity, AwayTeam = _norwich, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _westBrom, AwayTeam = _chelsea, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _wigan, AwayTeam = _swansea, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _newcastle, AwayTeam = _sunderland, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _fulham, AwayTeam = _wolves, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _tottenham, AwayTeam = _manUtd, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _arsenal, AwayTeam = _liverpool, Date = new DateTime(2012, 2, 25)});

            _fixtureList = new FixtureList { _gamesweek1 };
        }

        [Given(@"a fixture list has two gamesweeks")]
        public void GivenAFixtureListHasTwoGamesWeeks()
        {
            GivenAFixtureListHasOneGamesWeek();

            _gamesweek2 = new Gamesweek();

            _gamesweek2.AddFixture(new Fixture { HomeTeam = _astonVilla, AwayTeam = _fulham, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _chelsea, AwayTeam = _stokeCity, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _sunderland, AwayTeam = _liverpool, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _wolves, AwayTeam = _blackburn, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _everton, AwayTeam = _tottenham, Date = new DateTime(2012, 3, 10) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _manUtd, AwayTeam = _westBrom, Date = new DateTime(2012, 3, 11) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _swansea, AwayTeam = _manCity, Date = new DateTime(2012, 3, 11) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _norwich, AwayTeam = _wigan, Date = new DateTime(2012, 3, 11) });
            _gamesweek2.AddFixture(new Fixture { HomeTeam = _arsenal, AwayTeam = _newcastle, Date = new DateTime(2012, 3, 12) });
            
            _fixtureList.Add(_gamesweek2);
        }

        [Given(@"a fixture list has three gamesweeks")]
        public void GivenAFixtureListHasThreeGamesweeks()
        {
            GivenAFixtureListHasTwoGamesWeeks();

            _gamesweek3 = new Gamesweek();

            _gamesweek3.AddFixture(new Fixture { HomeTeam = _fulham, AwayTeam = _swansea, Date = new DateTime(2012, 3, 17) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _wigan, AwayTeam = _wolves, Date = new DateTime(2012, 3, 17) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _wolves, AwayTeam = _manUtd, Date = new DateTime(2012, 3, 18) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _newcastle, AwayTeam = _norwich, Date = new DateTime(2012, 3, 18) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _astonVilla, AwayTeam = _bolton, Date = new DateTime(2012, 3, 20) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _blackburn, AwayTeam = _sunderland, Date = new DateTime(2012, 3, 20) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _manCity, AwayTeam = _chelsea, Date = new DateTime(2012, 3, 21) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _tottenham, AwayTeam = _stokeCity, Date = new DateTime(2012, 3, 21) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _everton, AwayTeam = _arsenal, Date = new DateTime(2012, 3, 21) });
            _gamesweek3.AddFixture(new Fixture { HomeTeam = _qpr, AwayTeam = _liverpool, Date = new DateTime(2012, 3, 21) });

            _fixtureList.Add(_gamesweek3);
        }

        [Given(@"the first gamesweek is in progress")]
        public void GivenTheFirstGamesweekIsInProgress()
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

        [When(@"I get Wigan's next fixture from the next gamesweek")]
        public void WhenIGetWiganSNextFixtureFromTheNextGamesweek()
        {
            _returnedFixtures = _fixtureList.GetNextFixtures(_wigan, 1);
        }


        [Then(@"Wigan's fixture from the second gamesweek should be selected")]
        public void ThenWiganSFixtureFromTheSecondGamesWeekShouldBeSelected()
        {
            Assert.That(_returnedFixtures.Single().HomeTeam == _norwich, Is.True);
            Assert.That(_returnedFixtures.Single().AwayTeam == _wigan, Is.True);
        }

        [Given(@"Sunderland did not play in the first gamesweek")]
        public void GivenSunderlandDidNotPlayInTheFirstGamesWeek()
        {
            _gamesweek1._fixtures.Remove(_gamesweek1.GetFixturesForTeam(_sunderland).Single());
        }

        [Given(@"all the games have been played")]
        public void AllTheGamesHaveBeenPlayed()
        {
            foreach(var gamesweek in _fixtureList)
            {
                gamesweek.Started = true;
                gamesweek.Completed = true;

                foreach(var fixture in gamesweek)
                {
                    fixture.HomeGoals = 1;
                    fixture.AwayGoals = 2;
                    fixture.Played = true;
                }
            }
        }

        [When(@"I get Sunderland's last home fixture")]
        public void WhenIGetSunderlandSLastHomeFixture()
        {
            _sunderlandsLastHomeFixture = _fixtureList.GetLastXHomeFixturesForTeam(_sunderland, 1).Single();
        }

        [Then(@"Sunderland's fixture from the second gamesweek should be selected")]
        public void ThenSunderlandSFixtureFromTheSecondGamesWeekShouldBeSelected()
        {
            Assert.That(_sunderlandsLastHomeFixture.AwayTeam, Is.EqualTo(_liverpool));
        }

        [When(@"I get Sunderland's next fixture")]
        public void WhenIGetSunderlandSNextFixture()
        {
            _sunderlandsNextFixture = _fixtureList.GetNextFixtures(_sunderland, 1).Single();
        }

        [Then(@"Sunderland's fixture from the first gamesweek should be selected")]
        public void ThenSunderlandSFixtureFromTheFirstGamesWeekShouldBeSelected()
        {
            Assert.That(_sunderlandsNextFixture.HomeTeam, Is.EqualTo(_newcastle));
        }

        [Given(@"the first gamesweek has been completed")]
        public void GivenTheFirstGamesWeekHasBeenCompleted()
        {
            foreach(var fixture in _gamesweek1)
            {
                fixture.HomeGoals = 1;
                fixture.AwayGoals = 2;
                fixture.Played = true;
            }

            _gamesweek1.Completed = true;

            _gamesweek1.Started = true;
        }

        [When(@"I get Arsenal's last home fixture")]
        public void WhenIGetArsenalSLastHomeFixture()
        {
            _arsenalsLastHomeFixture = _fixtureList.GetLastXHomeFixturesForTeam(_arsenal, 1).Single();
        }

        [Then(@"Arsenal's fixture from the first gamesweek should be selected")]
        public void ThenArsenalSFixtureFromTheFirstGamesWeekShouldBeSelected()
        {
            Assert.That(_arsenalsLastHomeFixture.AwayTeam, Is.EqualTo(_liverpool));
        }

        [When(@"I get Arsenal's last two home fixtures")]
        public void WhenIGetArsenalSLastTwoHomeFixtures()
        {
            _returnedFixtures = _fixtureList.GetLastXHomeFixturesForTeam(_arsenal, 2);

            _arsenalsLastHomeFixture = _returnedFixtures.First();

            _arsenalsSecondLastHomeFixture = _returnedFixtures.Last();
        }

        [Then(@"Arsenal's fixture from the second gamesweek should be selected")]
        public void ThenArsenalSFixtureFromTheSecondGamesWeekShouldBeSelected()
        {
            Assert.That(_arsenalsSecondLastHomeFixture.AwayTeam, Is.EqualTo(_newcastle));
        }

        [Then(@"two fixtures should be selected")]
        public void ThenTwoFixturesShouldBeSelected()
        {
            Assert.That(_returnedFixtures.Count(), Is.EqualTo(2));
        }

        [Given(@"Wigan do not have a fixture in the second gamesweek")]
        public void GivenWiganDoNotHaveAFixtureInTheSecondGamesweek()
        {
            _gamesweek2._fixtures.Remove(_gamesweek2.GetFixtureForTeam(_wigan));
        }

        [When(@"I get Wigan's next two fixtures")]
        public void WhenIGetWiganSNextTwoFixtures()
        {
            _returnedFixtures = _fixtureList.GetNextFixtures(_wigan, 3);
        }

        [Then(@"Wigan's fixture from the first gamesweek should be returned")]
        public void ThenWiganSFixtureFromTheFirstGamesweekShouldBeReturned()
        {
            Assert.That(_returnedFixtures.First(), Is.EqualTo(_gamesweek1.GetFixtureForTeam(_swansea)));
        }
        
        [Then(@"Wigan's fixture from the third gamesweek should be returned")]
        public void ThenWiganSFixtureFromTheThirdGamesweekShouldBeReturned()
        {
            Assert.That(_returnedFixtures.Last(), Is.EqualTo(_gamesweek3.GetFixtureForTeam(_wolves)));
        }
    
        [Then(@"two fixtures should be returned")]
        public void ThenTwoFixturesShouldBeReturned()
        {
            Assert.That(_returnedFixtures.Count(), Is.EqualTo(2));
        }

        [Given(@"Stoke have two fixtures in the gamesweek")]
        public void GivenStokeHaveTwoFixturesInTheGamesweek()
        {
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _stokeCity, AwayTeam = _arsenal });
        }

        [When(@"I get Stoke's fixtures for the gamesweek")]
        public void WhenIGetStokeSFixturesForTheGamesweek()
        {
            _returnedFixtures = _fixtureList.GetNextFixtures(_stokeCity, 1);
        }

        [Then(@"Stoke's first fixture from the gamesweek should be returned")]
        public void ThenStokeSFirstFixtureFromTheGamesweekShouldBeReturned()
        {
            Assert.That(_returnedFixtures.Any(f => f.HomeTeam == _stokeCity && f.AwayTeam == _norwich), Is.True);
        }

        [Then(@"Stoke's second fixture from the second gamesweek should be returned")]
        public void ThenStokeSSecondFixtureFromTheSecondGamesweekShouldBeReturned()
        {
            Assert.That(_returnedFixtures.Any(f => f.HomeTeam == _stokeCity && f.AwayTeam == _arsenal), Is.True);
        }
    }
}