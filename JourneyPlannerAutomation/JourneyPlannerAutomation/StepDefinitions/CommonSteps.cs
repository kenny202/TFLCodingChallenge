using JourneyPlannerAutomation.Pages;
using JourneyPlannerAutomation.Setup;
using TechTalk.SpecFlow;

namespace JourneyPlannerAutomation.StepDefinitions
{
    [Binding]
   public class CommonSteps
    {

        Context _context;
        CommonPage _commmonPage;
        public CommonSteps(Context context, CommonPage commonPage)
        {
            _commmonPage = commonPage;
            _context = context;
        }

        [Given(@"that tfl web page is loaded")]
        public void GivenThatTflWebPageIsLoaded()
        {   
            _context.LoadApplicationUnderTest();
            _commmonPage.AcceptCookiesButton();
        }

        [AfterScenario]
        public void CloseApplicationUnderTest()
        {
            _context.ShutDownApplicationUnderTest();
        }

    }
}
