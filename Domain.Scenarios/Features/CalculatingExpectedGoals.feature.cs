﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.269
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dw.FantasyFootball.Domain.Scenarios.Features
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
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s next fixture when a gamesweek is in progress")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSNextFixtureWhenAGamesweekIsInProgress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s next fixture when a gamesweek is in progress", new string[] {
                        "nextFixture"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("a fixture list has two gamesweeks");
#line 9
 testRunner.And("the first gamesweek is in progress");
#line 10
 testRunner.When("I get Wigan\'s next fixture from the next gamesweek");
#line 11
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
#line 14
this.ScenarioSetup(scenarioInfo);
#line 15
 testRunner.Given("a fixture list has two gamesweeks");
#line 16
 testRunner.And("Sunderland did not play in the first gamesweek");
#line 17
 testRunner.And("all the games have been played");
#line 18
 testRunner.When("I get Sunderland\'s last home fixture");
#line 19
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
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("a fixture list has two gamesweeks");
#line 24
 testRunner.When("I get Sunderland\'s next fixture");
#line 25
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
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("a fixture list has two gamesweeks");
#line 30
 testRunner.And("the first gamesweek has been completed");
#line 31
 testRunner.When("I get Arsenal\'s last home fixture");
#line 32
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
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
 testRunner.Given("a fixture list has two gamesweeks");
#line 37
 testRunner.And("all the games have been played");
#line 38
 testRunner.When("I get Arsenal\'s last two home fixtures");
#line 39
 testRunner.Then("Arsenal\'s fixture from the first gamesweek should be selected");
#line 40
 testRunner.And("Arsenal\'s fixture from the second gamesweek should be selected");
#line 41
 testRunner.And("two fixtures should be selected");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s next two fixtures when they don\'t have a fixture in the second g" +
            "amesweek")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSNextTwoFixturesWhenTheyDonTHaveAFixtureInTheSecondGamesweek()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s next two fixtures when they don\'t have a fixture in the second g" +
                    "amesweek", new string[] {
                        "nextFixture"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("a fixture list has three gamesweeks");
#line 46
 testRunner.And("Wigan do not have a fixture in the second gamesweek");
#line 47
 testRunner.When("I get Wigan\'s next two fixtures");
#line 48
 testRunner.Then("Wigan\'s fixture from the first gamesweek should be returned");
#line 49
 testRunner.And("Wigan\'s fixture from the third gamesweek should be returned");
#line 50
 testRunner.And("two fixtures should be returned");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Getting a team\'s fixtures for a double gamesweek")]
        [NUnit.Framework.CategoryAttribute("nextFixture")]
        public virtual void GettingATeamSFixturesForADoubleGamesweek()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Getting a team\'s fixtures for a double gamesweek", new string[] {
                        "nextFixture"});
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("a fixture list has one gamesweek");
#line 55
 testRunner.And("Stoke have two fixtures in the gamesweek");
#line 56
 testRunner.When("I get Stoke\'s fixtures for the gamesweek");
#line 57
 testRunner.Then("two fixtures should be returned");
#line 58
 testRunner.And("Stoke\'s first fixture from the gamesweek should be returned");
#line 59
 testRunner.And("Stoke\'s second fixture from the second gamesweek should be returned");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
