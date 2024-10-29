using TechTalk.SpecFlow;

namespace IntroductionCSharp.Steps

{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void SetupTest(FeatureContext featureContext)
        {
            Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
        }
    }
}
