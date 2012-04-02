using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DW.FantasyFootball.Domain;
using log4net;
using MathNet.Numerics.Distributions;

namespace DW.FantasyFootball.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();

                ILog _logger = LogManager.GetLogger("logger");

                var fixtureList = FixtureScrapper.GetLeague();

                var league = new League(fixtureList, _logger);

                var stats = new Stats();

                foreach(var teamData in league)
                {
                    var nextFixtures = league.FixtureList.GetNextFixtures(teamData.Key, 11);

                    foreach (var nextFixture in nextFixtures)
                    {
                        // nextFixture = league.FixtureList.GetNextGamesweeksFixture(teamData.Key, _logger);

                        if (nextFixture == null)
                            break;

                        var homeFixtures = league.FixtureList.GetLastXHomeFixturesForTeam(nextFixture.HomeTeam, 6);

                        var awayFixtures = league.FixtureList.GetLastXAwayFixturesForTeam(nextFixture.AwayTeam, 6);

                        var expectedHomeGoals = (homeFixtures.Average(f => (decimal)f.HomeGoals) + awayFixtures.Average(f => (decimal)f.HomeGoals)) / 2m;

                        var expectedAwayGoals = (awayFixtures.Average(f => (decimal)f.AwayGoals) + homeFixtures.Average(f => (decimal)f.AwayGoals)) / 2m;

                        if (nextFixture.HomeTeam == teamData.Key)
                        {
                            stats.AddFutureFixture(nextFixture.HomeTeam, new StatFixture(expectedHomeGoals, expectedAwayGoals));
                        }
                        else
                        {
                            stats.AddFutureFixture(nextFixture.AwayTeam, new StatFixture(expectedAwayGoals, expectedHomeGoals));
                        }

                        /*System.Console.WriteLine(
                            string.Format("{0} v {1} for {2} against {3}",
                            nextFixture.HomeTeam,
                            nextFixture.AwayTeam,
                            expectedHomeGoals.ToString("{0.00}"),
                            expectedAwayGoals.ToString("{0.00}"))
                        );*/
                    }
                }

                System.Console.WriteLine("\nDefensive Stats");

                foreach(var stat in stats.OrderedByProbabilityOfAtLeastOneCleanSheet())
                {
                    System.Console.WriteLine(stat.Key.Name + " " + stat.Value.ProbabilityOfAtLeastOneCleanSheet);
                }

                System.Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: {0}", ex.Message);
            }

            System.Console.ReadKey(true);
        }
    }

    public class StatFixture
    {
        private readonly decimal _goalsFor;
        private readonly decimal _goalsAgainst;

        public StatFixture(decimal goalsFor, decimal goalsAgainst)
        {
            _goalsFor = goalsFor;
            _goalsAgainst = goalsAgainst;
        }

        public decimal GoalsAgainst
        {
            get { return _goalsAgainst; }
        }

        public decimal GoalsFor
        {
            get { return _goalsFor; }
        }

        public double ProbabilityOfCleanSheet
        {
            get
            {
                var poisson = new Poisson(Decimal.ToDouble(_goalsAgainst));

                return poisson.Probability(0);
            }
        }
    }

    public class StatFixtureList : IEnumerable<StatFixture>
    {
        private List<StatFixture> _statFixtures;

        public void Add(StatFixture statFixture)
        {
            if (_statFixtures == null)
            {
                _statFixtures = new List<StatFixture>();
            }

            _statFixtures.Add(statFixture);
        }

        public decimal DefensivePoints
        {
            get { return _statFixtures.Average(s => s.GoalsAgainst); }
        }

        public decimal OffensivePoints
        {
            get { return _statFixtures.Average(s => s.GoalsFor); }
        }

        public double ProbabilityOfAtLeastOneCleanSheet
        {
            get { return 1.0 - _statFixtures.Aggregate(1.0, (x, y) => x * (1.0 - y.ProbabilityOfCleanSheet)); }
        }

        public IEnumerator<StatFixture> GetEnumerator()
        {
            return _statFixtures.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Stats : IEnumerable<KeyValuePair<Team, StatFixtureList>>
    {
        private Dictionary<Team, StatFixtureList> _stats;

        public void AddFutureFixture(Team team, StatFixture statFixture)
        {
            if (_stats == null)
            {
                _stats = new Dictionary<Team, StatFixtureList>();
            }

            if (!_stats.ContainsKey(team))
            {
                _stats.Add(team, new StatFixtureList());
            }

            _stats[team].Add(statFixture);
        }

        public IEnumerator<KeyValuePair<Team, StatFixtureList>> GetEnumerator()
        {
            return _stats.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByDefensivePoints()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderBy(s => s.Value.DefensivePoints);
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByOffensivePoints()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderByDescending(s => s.Value.OffensivePoints);
        }

        public IOrderedEnumerable<KeyValuePair<Team, StatFixtureList>> OrderedByProbabilityOfAtLeastOneCleanSheet()
        {
            return _stats
                .OfType<KeyValuePair<Team, StatFixtureList>>()
                .OrderByDescending(s => s.Value.ProbabilityOfAtLeastOneCleanSheet);
        }
    }

    public class StrengthCalculator
    {
    }
}