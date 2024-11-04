using FluentAssertions;
using IntroductionCSharp.Infrastructure;
using IntroductionCSharp.Models;
using System;
using System.Text.Json.Nodes;
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

        [When(@"I send a complex message")]
        public void WhenISendAComplexMessage()
        {
            var message = "{'type': 'complex', 'content': {'text': 'Hello', 'number': 123}}";
            Broker.SendMessage(message, "testing");
        }

        [When(@"I send a list message")]
        public void WhenISendAListMessage()
        {
            var message = "{'type': 'list', 'content': ['item1', 'item2', 'item3' ]}";
            Broker.SendMessage(message, "testing");
        }

        [Then(@"the message type complex is valided")]
        public void ThenTheMessageTypeComplexIsValided()
        {
            dynamic result = Broker.GetMessage<object>("testing");
            var typeMessage = (String)result.type;
            var text = (String)result.content.text;
            var number = (int)result.content.number;

            typeMessage.Should().Be("complex");
            text.Should().Be("Hello");
            number.Should().Be(123);
        }

        [Then(@"the message type list is valided")]
        public void ThenTheMessageTypeListIsValided()
        {
            var result = Broker.GetMessage<MessageTypeList>("testing");
            result.Type.Should().Be("list");
            result.Content.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.Equal(new List<String> { "item1", "item2", "item3" });
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
