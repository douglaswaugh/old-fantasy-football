﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.1.84
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AlgorithimFinder.Scenarios
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PredictingPlayerPoints")]
    public partial class PredictingPlayerPointsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PredictingPlayerPoints.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PredictingPlayerPoints", "In order to beat everyone at fantasy football\r\nAs a fantasy football manager\r\nI w" +
                    "ant to know which players to buy and sell", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        [NUnit.Framework.DescriptionAttribute("Predict goalkeeper points")]
        public virtual void PredictGoalkeeperPoints()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Predict goalkeeper points", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("the \"Wigan\" \"Wolves\" result on the \"13-Oct-11\" was 3 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("the \"Wolves\" \"Wigan\" result on the \"13-Nov-11\" was 3 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Round",
                        "Opponent",
                        "Minutes",
                        "GoalsScored",
                        "Assists",
                        "CleanSheets",
                        "GoalsConceded",
                        "OwnGoals",
                        "PenaltiesSaved",
                        "PenaltiesMissed",
                        "YellowCards",
                        "RedCards",
                        "Saves",
                        "Bonus",
                        "Points"});
            table1.AddRow(new string[] {
                        "1",
                        "CHE(H) 0-2",
                        "90",
                        "0",
                        "0",
                        "0",
                        "2",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "1",
                        "0",
                        "1"});
            table1.AddRow(new string[] {
                        "2",
                        "SOU(A) 2-0",
                        "90",
                        "0",
                        "0",
                        "1",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "6",
                        "2",
                        "10"});
            table1.AddRow(new string[] {
                        "3",
                        "STK(H) 2-2",
                        "90",
                        "0",
                        "0",
                        "0",
                        "2",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "5",
                        "0",
                        "2"});
            table1.AddRow(new string[] {
                        "4",
                        "MUN(A) 0-4",
                        "90",
                        "0",
                        "0",
                        "0",
                        "4",
                        "0",
                        "1",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "5"});
            table1.AddRow(new string[] {
                        "5",
                        "FUL(H) 1-2",
                        "90",
                        "0",
                        "0",
                        "0",
                        "2",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "6",
                        "0",
                        "3"});
#line 9
 testRunner.And("\"Al Habsi\" has the history", ((string)(null)), table1, "And ");
#line 16
 testRunner.When("I ask for a points prediction for \"Al Habsi\" of \"Wigan\" for matches after \"13-Nov" +
                    "-11\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("I should be told \"Al Habsi\" will get \"1.51\" points", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Predict defender points")]
        public virtual void PredictDefenderPoints()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Predict defender points", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
 testRunner.Given("the \"Wigan\" \"Wolves\" result on the \"13-Oct-11\" was 3 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
 testRunner.And("the \"Wolves\" \"Wigan\" result on the \"13-Nov-11\" was 3 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("the players of \"Wigan\" have a history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I ask for a points prediction for \"Figueroa\" of \"Wigan\" for matches after \"13-Nov" +
                    "-11\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
 testRunner.Then("I should be told \"Figueroa\" will get \"6.83\" points", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Predict midfielder points")]
        public virtual void PredictMidfielderPoints()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Predict midfielder points", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
 testRunner.Given("the \"Wigan\" \"Wolves\" result on the \"13-Oct-11\" was 3 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 28
 testRunner.And("the \"Wolves\" \"Wigan\" result on the \"13-Nov-11\" was 3 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("the players of \"Wigan\" have a history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I ask for a points prediction for \"Maloney\" of \"Wigan\" for matches after \"13-Nov-" +
                    "11\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("I should be told \"Maloney\" will get \"4.75\" points", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Predict forward points")]
        public virtual void PredictForwardPoints()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Predict forward points", ((string[])(null)));
#line 33
this.ScenarioSetup(scenarioInfo);
#line 34
 testRunner.Given("the \"Wigan\" \"Wolves\" result on the \"13-Oct-11\" was 3 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
 testRunner.And("the \"Wolves\" \"Wigan\" result on the \"13-Nov-11\" was 3 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("the players of \"Wigan\" have a history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("I ask for a points prediction for \"Kone\" of \"Wigan\" for matches after \"13-Nov-11\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("I should be told \"Kone\" will get \"8.64\" points", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
