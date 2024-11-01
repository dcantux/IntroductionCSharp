using FluentAssertions;
using IntroductionCSharp.Infrastructure;
using System;
using TechTalk.SpecFlow;

namespace IntroductionCSharp.Steps
{
    [Binding]
    public class BrokerStepDefinitions
    {
        [When(@"I send a simple message (.*)")]
        public void WhenISendASimpleMessage(String message)
        {
            var messageCompose = @"{'type': 'simple', 'content': '@MESSAGE' }".Replace("@MESSAGE", message);
            Broker.SendMessage(messageCompose, "testing");
        }

        [Then(@"the message (.*) is accessible")]
        public void ThenTheMessageIsAccessible(String message)
        {
            dynamic result = Broker.GetMessage<object>("testing");
            var typeMessage = (String)result.type;
            typeMessage.Should().Be("simple");
            message.Should().Be((String)result.content);
        }
    }
}
