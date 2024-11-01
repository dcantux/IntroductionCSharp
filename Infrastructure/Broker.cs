using DotNet.Testcontainers.Builders;
using IntroductionCSharp.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Testcontainers.RabbitMq;


namespace IntroductionCSharp.Infrastructure
{
    public class Broker
    {

        private static readonly string _username = "testing";
        private static readonly string _password = "testing";
        private static readonly string _hostname = "localhost";


        private static IModel GetChannel()
        {
            var factory = new ConnectionFactory() { HostName = _hostname, Port = 5672, UserName = _username, Password = _password };
            var connection = factory.CreateConnection();
            return connection.CreateModel();
        }



        private static String _stateContainerRabbitmq = "";
        public static void RunInstanceRabbitMQ()
        {
            if (_stateContainerRabbitmq != "Running")
            {
                var rabbitMqContainer = new RabbitMqBuilder()
                    .WithImage("rabbitmq:3.11-management")
                    .WithUsername("testing")
                    .WithPassword("testing")
                    .WithExposedPort(5672)
                    .WithExposedPort(15672)
                    .WithPortBinding(5672, 5672)
                    .WithPortBinding(15672, 15672)
                    .WithWaitStrategy(Wait.ForWindowsContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(15672)))
                    .Build();
                Task.WaitAll(Task.Run(() => rabbitMqContainer.StartAsync()));
                _stateContainerRabbitmq = rabbitMqContainer.State.ToString();
            }
        }

        public static void SendMessage(String message, String queue)
        {
            var channel = GetChannel();
            channel.QueueDeclare(queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
            
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: body);
        }

        public static T GetMessage<T>(String queue)
        {
            var channel = GetChannel();
            channel.QueueDeclare(queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            var result = channel.BasicGet(queue, false);

            return JsonUtils.Deserialize<T>(Encoding.UTF8.GetString(result.Body.ToArray()));
        }
    }
}
