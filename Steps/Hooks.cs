using IntroductionCSharp.Infrastructure;
using TechTalk.SpecFlow;

namespace IntroductionCSharp.Steps

{
    [Binding]
    public class Hooks
    {
        
        [Before]
        public void SetupTest(FeatureContext featureContext)
        {
            Broker.RunInstanceRabbitMQ();
            Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
        }
    }
}
