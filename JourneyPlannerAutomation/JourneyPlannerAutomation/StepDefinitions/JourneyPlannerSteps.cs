using TechTalk.SpecFlow;
using JourneyPlannerAutomation.Pages;
using JourneyPlannerAutomation.Setup;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using JourneyPlannerAutomation.Model;

namespace JourneyPlannerAutomation.StepDefinitions
{
    [Binding]
    public class JourneyPlannerSteps
    {
        
        Initialiser _context;
        JourneyPlannerPage _journeyPlannerPage;
        public JourneyPlannerSteps(Initialiser context, JourneyPlannerPage journeyPlannerPage)
        {
            _context = context;
            _journeyPlannerPage = journeyPlannerPage;           
        }
     
        [When(@"I click on Plan a journey link")]
        public void WhenIClickOnLink()
        {
            _journeyPlannerPage.ClickPlanAJourneyLink();
        }

        [When(@"I fill-in '(.*)' into the From field")]
        public void WhenIFill_InIntoTheFromField(string fromAddress)
        {
            _journeyPlannerPage.FillFromField(fromAddress);
        }
        
        [When(@"I fill-in '(.*)' into the To field")]
        public void WhenIFill_InIntoTheToField(string toAddress)
        {
            _journeyPlannerPage.FillToField(toAddress);
        }
        
        [When(@"I click on Plan my journey tab")]
        public void WhenIUserClicksOnPlanMyJourneyTab()
        {
            _journeyPlannerPage.ClickPlanMyJourneyTab();
        }
        
        [When(@"I fill-in To and From fields below data")]
        public void WhenIFill_InToAndFromFieldsBelowData(Table table)
        {
            var tableData = table.CreateInstance<JourneyPlannerModel>();
            _journeyPlannerPage.FillFromField(tableData.From);
            _journeyPlannerPage.FillToField(tableData.To);
        }   
       
        
        [When(@"I fill-in addresses into (.*) and (.*) fields")]
        public void WhenIFill_InAddressesIntoAndFields(string fromField, string toField)
        {
            _journeyPlannerPage.FillFromField(fromField);
            _journeyPlannerPage.FillToField(toField);
        }        
       
        [When(@"I click on Edit Journey link")]
        public void WhenIClickOnEditJourneyLink()
        {
            _journeyPlannerPage.ClickOnEditJourneyButton();            
        }
        
        [When(@"I click on Update Journey link")]
        public void WhenIClickOnUpdateJourneyLink()
        {
            _journeyPlannerPage.ClickOnUpdateJourneyButton();
        }

        [When(@"I click on Recents tab")]
        public void WhenIClickOnTab()
        {
            _journeyPlannerPage.ClickOnRecentsLink();
        }
        
        [Then(@"Journey result page should display '(.*)'")]
        public void ThenJourneyResultPageShouldDisplayTFindAJourneyMatchingYourCriteria(string expectedErrorMessage)
        {
            Assert.AreEqual(_journeyPlannerPage.ReturnInvalidSearchErrorMessage(), expectedErrorMessage, "Expected error message is not equal to actual error message");
        }
        
        [Then(@"View details button should be displayed")]
        public void ThenMyJourneyShouldBeCreated()
        {        
            Assert.IsTrue(_journeyPlannerPage.VerifyViewDetailsLink(),$"View details button is not displayed");
        }
        
        [Then(@"my recent journey '(.*)' should be displayed")]
        public void ThenMyRecentJourneyShouldBeDisplayed(string expectedRecentText)
        {
            Assert.IsTrue(_journeyPlannerPage.RecentSearchText().Contains(expectedRecentText));
        }

        [Then(@"my journey (.*) should be created")]
        public void ThenMyJourneyShouldBeCreated(string expectedErrorMessage)
        {
            string actualErrorMessage = string.Empty;

            if (expectedErrorMessage.Equals("The From field is required."))
            {
                actualErrorMessage = _journeyPlannerPage.ReturnFromFieldErrorMessage();
            }
            else if (expectedErrorMessage.Equals("The To field is required."))
            {
                actualErrorMessage = _journeyPlannerPage.ReturnToFieldErrorMessage();
            }

            Assert.AreEqual(actualErrorMessage, expectedErrorMessage, "Actual result is not equal to expected result");

        }

    }
}
