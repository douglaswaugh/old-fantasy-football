﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.261
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dw.FantasyFootball.Domain.Scenarios
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Strength of opponents")]
    public partial class StrengthOfOpponentsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CalculatingExpectedGoals.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Strength of opponents", "In order to calculate the ease of upcoming fixtures\r\nAs a fantasy football team m" +
                    "anager\r\nI want to calculate the odds of goals being scored by the home and away " +
                    "teams", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s next fixture when a team has two games in one gamesweek")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSNextFixtureWhenATeamHasTwoGamesInOneGamesweek()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s next fixture when a team has two games in one gamesweek", new string[] {
                        "nextFixture"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("a fixture list has one gamesweek");
#line 9
 testRunner.And("Liverpool have two fixtures in the gamesweek");
#line 10
 testRunner.When("I get Liverpool\'s next fixture");
#line 11
 testRunner.Then("the first fixture should be selected");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s next fixture when a gamesweek is in progress")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSNextFixtureWhenAGamesweekIsInProgress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s next fixture when a gamesweek is in progress", new string[] {
                        "nextFixture"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("a fixture list has two gamesweeks");
#line 16
 testRunner.And("the first gamesweek is in progress");
#line 17
 testRunner.When("I get Wigan\'s next fixture");
#line 18
 testRunner.Then("Wigan\'s fixture from the second gamesweek should be selected");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s last home fixture when they did not play in all gamesweeks")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSLastHomeFixtureWhenTheyDidNotPlayInAllGamesweeks()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s last home fixture when they did not play in all gamesweeks", new string[] {
                        "nextFixture"});
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
 testRunner.Given("a fixture list has two gamesweeks");
#line 23
 testRunner.And("Sunderland did not play in the first gamesweek");
#line 24
 testRunner.And("all the games have been played");
#line 25
 testRunner.When("I get Sunderland\'s last home fixture");
#line 26
 testRunner.Then("Sunderland\'s fixture from the second gamesweek should be selected");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s next fixture when there is more than one gamesweek to play")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSNextFixtureWhenThereIsMoreThanOneGamesweekToPlay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s next fixture when there is more than one gamesweek to play", new string[] {
                        "nextFixture"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("a fixture list has two gamesweeks");
#line 31
 testRunner.When("I get Sunderland\'s next fixture");
#line 32
 testRunner.Then("Sunderland\'s fixture from the first gamesweek should be selected");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s last home fixture when there are more games to play")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSLastHomeFixtureWhenThereAreMoreGamesToPlay()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s last home fixture when there are more games to play", new string[] {
                        "nextFixture"});
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("a fixture list has two gamesweeks");
#line 37
 testRunner.And("the first gamesweek has been completed");
#line 38
 testRunner.When("I get Arsenal\'s last home fixture");
#line 39
 testRunner.Then("Arsenal\'s fixture from the first gamesweek should be selected");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s last 2 home fixtures")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSLast2HomeFixtures()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s last 2 home fixtures", new string[] {
                        "nextFixture"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("a fixture list has two gamesweeks");
#line 44
 testRunner.And("all the games have been played");
#line 45
 testRunner.When("I get Arsenal\'s last two home fixtures");
#line 46
 testRunner.Then("Arsenal\'s fixture from the first gamesweek should be selected");
#line 47
 testRunner.And("Arsenal\'s fixture from the second gamesweek should be selected");
#line 48
 testRunner.And("two fixtures should be selected");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
