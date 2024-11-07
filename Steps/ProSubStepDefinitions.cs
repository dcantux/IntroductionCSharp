using FluentAssertions;
using IntroductionCSharp.Infrastructure;
using IntroductionCSharp.Models;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace IntroductionCSharp.Steps
{
    [Binding]
    public sealed class ProSubStepDefinitions
    {
        [When(@"I send message")]
        public void WhenISendMessage()
        {
            const string myTopic = "persistent://public/default/mytopic";
            var message = "{'type': 'simple', 'content': 'Hello, Pulsar World' }";
            ProSub.SendMessage(myTopic, message);
        }

        [When(@"I send message with multiple fields")]
        public void WhenISendMessageWithMultipleFileds()
        {
            const string myTopic = "persistent://public/default/mytopic";
            var message = "{'type': 'complex', 'content': {'text': 'Hello Pulsar', 'number': 123} }";
            ProSub.SendMessage(myTopic, message);
        }

        //
        [When(@"I send message with a list")]
        public void WhenISendMessageWithList()
        {
            const string myTopic = "persistent://public/default/mytopic";
            var message = "{'type': 'list', 'content': [ 'item1', 'item2', 'item3'] }";
            ProSub.SendMessage(myTopic, message);
        }


        [Then(@"the message is accessible")]
        public async Task ThenTheMessageIsAccessible()
        {
            const string myTopic = "persistent://public/default/mytopic";
            dynamic message = await ProSub.GetMessage<object>(myTopic);
            
            var typeMessage = (string)message?.type;
            typeMessage.Should().Be("simple");

            var content = (string)message?.content;
            content.Should().Be("Hello, Pulsar World");
        }

        [Then(@"the message multiple fields is verified")]
        public async Task ThenTheMessageMultipleFiledsIsVerified()
        {
            const string myTopic = "persistent://public/default/mytopic";
            dynamic result = await ProSub.GetMessage<object>(myTopic);
            
            var typeMessage = (string)result?.type;
            var text = (string)result.content?.text;
            var number = (int)result.content?.number;

            typeMessage.Should().Be("complex");
            text.Should().Be("Hello Pulsar");
            number.Should().Be(123);
        }

        [Then(@"the message with a list is verified")]
        public async Task ThenTheMessageWithAListIsVerified()
        {
            const string myTopic = "persistent://public/default/mytopic";
            var result = await ProSub.GetMessage<MessageTypeList>(myTopic);

            result?.Type.Should().Be("list");
            result?.Content.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.Equal(new List<String> { "item1", "item2", "item3" });
        }
    }
}
