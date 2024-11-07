// See https://aka.ms/new-console-template for more information

using IntroductionCSharp.Infrastructure;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json.Nodes;

//var db = Sql.Instance;
//var reader = Sql.Query("SELECT name FROM users;", db);
//while (reader.Read()) Console.WriteLine(reader.GetString(0));

using DotPulsar;
using DotPulsar.Extensions;

//const string myTopic = "persistent://public/default/mytopic";
//ProSub.SendMessage(myTopic, "Holaaaa");
//ProSub.GetMessage(myTopic);



/*
// connecting to pulsar://localhost:6650
await using var client = PulsarClient.Builder().Build();

// produce a message
await using var producer = client.NewProducer(Schema.String).Topic(myTopic).Create();
await producer.Send("Hello World");

// consume messages
await using var consumer = client.NewConsumer(Schema.String)
    .SubscriptionName("MySubscription")
    .Topic(myTopic)
    .InitialPosition(SubscriptionInitialPosition.Earliest)
    .Create();

await foreach (var message in consumer.Messages())
{
    Console.WriteLine($"Received: {message.Value()}");
    await consumer.Acknowledge(message);
}
*/


/*
Broker.RunInstanceRabbitMQ();
var messageSend = @"{'Test': 'testing'}";
Broker.SendMessage(messageSend, "testing");
dynamic message = Broker.GetMessage<object>("testing");
Console.WriteLine("ACAAAAAAAAAA");
//dynamic message = JsonConvert.DeserializeObject<object>(messageSend);
Console.WriteLine(message);
Console.WriteLine(message.Test);
Thread.Sleep(10000);
*/