using DotNet.Testcontainers.Builders;
using DotPulsar;
using DotPulsar.Extensions;
using IntroductionCSharp.Utils;
using System.Buffers;
using System.Text;
using Testcontainers.Pulsar;


namespace IntroductionCSharp.Infrastructure
{
    public class ProSub
    {

        private static String _stateContainerPulsar = "";


        public static void RunInstancePulsar()
        {

            if (_stateContainerPulsar != "Running")
            {
                var pulsarContainer = new PulsarBuilder()
                    .WithImage("apachepulsar/pulsar:3.0.0")
                    .WithExposedPort(8080)
                    .WithExposedPort(6650)
                    .WithPortBinding(8080, 8080)
                    .WithPortBinding(6650, 6650)
                    .WithWaitStrategy(Wait.ForWindowsContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(6650)))
                    .Build();
                Task.WaitAll(Task.Run(() => pulsarContainer.StartAsync()));
                _stateContainerPulsar = pulsarContainer.State.ToString();
            }
        }


        public static void SendMessage(String topic, String message)
        {
            var client = PulsarClient.Builder().Build();
            var producer = client.NewProducer(Schema.String).Topic(topic).Create();
            Task.WaitAll(Task.Run(() => producer.Send(message)));
        }

        public static async Task<T?> GetMessage<T>(String topic)
        {
            await using var client = PulsarClient.Builder().Build();
            await using var consumer = client.NewConsumer(Schema.String)
                .SubscriptionName("MySubscription")
                .Topic(topic)
                .InitialPosition(SubscriptionInitialPosition.Earliest)
                .Create();

            await foreach (var message in consumer.Messages())
            {
                await consumer.Acknowledge(message);
                return JsonUtils.Deserialize<T>(Encoding.UTF8.GetString(message.Data.ToArray()));
            }
            return default;
        }

    }
}
