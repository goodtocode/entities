using System;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Business
{
    [Binding]
    public class BusinessInsertSteps
    {
        [Given(@"I have an empty business key")]
        public void GivenIHaveAnEmptyBusinessKey()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the business name is provided")]
        public void GivenTheBusinessNameIsProvided()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Business is posted via Azure Function")]
        public void WhenBusinessIsPostedViaAzureFunction()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the business does not exist in persistence")]
        public void WhenTheBusinessDoesNotExistInPersistence()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Business is posted via Entity Framework")]
        public void WhenBusinessIsPostedViaEntityFramework()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the business is inserted to persistence")]
        public void ThenTheBusinessIsInsertedToPersistence()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
