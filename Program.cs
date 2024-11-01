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

Broker.RunInstanceRabbitMQ();
var messageSend = @"{'Test': 'testing'}";
Broker.SendMessage(messageSend, "testing");
dynamic message = Broker.GetMessage<object>("testing");
Console.WriteLine("ACAAAAAAAAAA");
//dynamic message = JsonConvert.DeserializeObject<object>(messageSend);
Console.WriteLine(message);
Console.WriteLine(message.Test);
Thread.Sleep(10000);
