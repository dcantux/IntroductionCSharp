using IntroductionCSharp.Infrastructure;
using TechTalk.SpecFlow;

namespace IntroductionCSharp.Steps

{
    [Binding]
    public class Hooks
    {
        
        [Before]
        public async Task SetupTest(FeatureContext featureContext)
        {
            
            if (featureContext.FeatureInfo.Title.Equals("TestBroker"))
            {
                Console.WriteLine("Starting RabbitMQ service...");
                Broker.RunInstanceRabbitMQ();
            }

            if (featureContext.FeatureInfo.Title.Equals("TestProSub"))
            {
                Console.WriteLine("Starting Pulsar service...");
                ProSub.RunInstancePulsar();
            }
            
            Console.WriteLine("Starting " + featureContext.FeatureInfo.Title);
        }
    }
}
