﻿using System;
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

        private Gamesweek _gamesweek;
        private Fixture _nextFixture;
        private Fixture _firstFixture;
        private Team _bolton = new Team("Bolton");
        private Team _qpr = new Team("QPR");
        private Gamesweek _gamesweek1;
        private Fixture _wigansNextFixture;
        private Fixture _wigansSecondFixture;
        private Fixture _sunderlandsLastHomeFixture;
        private Gamesweek _gamesweek2;
        private Fixture _sunderlandsNextFixture;
        private Fixture _arsenalsLastHomeFixture;
        private Fixture _arsenalsSecondLastHomeFixture;
        private IEnumerable<Fixture> _arsenalsLastTwoFixtures;

        [Given(@"a fixture list has one gamesweek")]
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

        [Given(@"Liverpool have two fixtures in the gamesweek")]
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


        [Given(@"a fixture list has two gamesweeks")]
        public void GivenAFixtureListHasTwoGamesWeeks()
        {
            _gamesweek1 = new Gamesweek();

            var wiganFirstFixture = new Fixture
                                         {HomeTeam = _wigan, AwayTeam = _swansea, Date = new DateTime(2012, 2, 25)};

            _gamesweek1.AddFixture(new Fixture { HomeTeam = _blackburn, AwayTeam = _astonVilla, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _manCity, AwayTeam = _bolton, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _qpr, AwayTeam = _everton, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _stokeCity, AwayTeam = _norwich, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _westBrom, AwayTeam = _chelsea, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(wiganFirstFixture);
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _newcastle, AwayTeam = _sunderland, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _fulham, AwayTeam = _wolves, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _tottenham, AwayTeam = _manUtd, Date = new DateTime(2012, 2, 25) });
            _gamesweek1.AddFixture(new Fixture { HomeTeam = _arsenal, AwayTeam = _liverpool, Date = new DateTime(2012, 2, 25)});

            _gamesweek2 = new Gamesweek();

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

        [When(@"I get Wigan's next fixture")]
        public void WhenIGetWiganSNextFixture()
        {
            var logger = MockRepository.GenerateStub<ILog>();

            _wigansNextFixture = _fixtureList.GetNextGamesweeksFixture(_wigan, logger);
        }

        [Then(@"Wigan's fixture from the second gamesweek should be selected")]
        public void ThenWiganSFixtureFromTheSecondGamesWeekShouldBeSelected()
        {
            Assert.That(_wigansNextFixture, Is.EqualTo(_wigansSecondFixture));
        }

        [Given(@"Sunderland did not play in the first gamesweek")]
        public void GivenSunderlandDidNotPlayInTheFirstGamesWeek()
        {
            _gamesweek1._fixtures.Remove(_gamesweek1.GetFixtureForTeam(_sunderland));
        }

        [Given(@"all the games have been played")]
        public void AllTheGamesHaveBeenPlayed()
        {
            foreach(var gamesweek in _fixtureList)
            {
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
            _sunderlandsLastHomeFixture = _fixtureList.GetLastHomeFixture(_sunderland);
        }

        [Then(@"Sunderland's fixture from the second gamesweek should be selected")]
        public void ThenSunderlandSFixtureFromTheSecondGamesWeekShouldBeSelected()
        {
            Assert.That(_sunderlandsLastHomeFixture.AwayTeam, Is.EqualTo(_liverpool));
        }

        [When(@"I get Sunderland's next fixture")]
        public void WhenIGetSunderlandSNextFixture()
        {
            _sunderlandsNextFixture = _fixtureList.GetNextGamesweeksFixture(_sunderland, null);
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
            _arsenalsLastHomeFixture = _fixtureList.GetLastHomeFixture(_arsenal);
        }

        [Then(@"Arsenal's fixture from the first gamesweek should be selected")]
        public void ThenArsenalSFixtureFromTheFirstGamesWeekShouldBeSelected()
        {
            Assert.That(_arsenalsLastHomeFixture.AwayTeam, Is.EqualTo(_liverpool));
        }

        [When(@"I get Arsenal's last two home fixtures")]
        public void WhenIGetArsenalSLastTwoHomeFixtures()
        {
            _arsenalsLastTwoFixtures = _fixtureList.GetLastXHomeFixturesForTeam(_arsenal, 2);

            _arsenalsLastHomeFixture = _arsenalsLastTwoFixtures.First();

            _arsenalsSecondLastHomeFixture = _arsenalsLastTwoFixtures.Last();
        }

        [Then(@"Arsenal's fixture from the second gamesweek should be selected")]
        public void ThenArsenalSFixtureFromTheSecondGamesWeekShouldBeSelected()
        {
            Assert.That(_arsenalsSecondLastHomeFixture.AwayTeam, Is.EqualTo(_newcastle));
        }

        [Then(@"two fixtures should be selected")]
        public void ThenTwoFixturesShouldBeSelected()
        {
            Assert.That(_arsenalsLastTwoFixtures.Count(), Is.EqualTo(2));
        }
    }
}