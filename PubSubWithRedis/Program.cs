using System;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace PubSubDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect("localhost:6379");
            var pubsub = connection.GetSubscriber();

            Task.Run(() => Publish(pubsub, "A"));
            Task.Run(() => Subscribe(pubsub, "B"));
            Task.Run(() => Subscribe(pubsub, "C"));
            Task.Run(() => Subscribe(pubsub, "D"));

            Console.ReadKey();
        }

        private static void Subscribe(ISubscriber sub, string consumerName)
        {
            sub.Subscribe("koperta", (channel, value) => Console.WriteLine($"{consumerName} odebralem: {value}"));
        }
        
        private static void Publish(ISubscriber sub, string publisherName)
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"{publisherName} Wyslalem wiadomoc {i}");
                sub.Publish("koperta", $"Tresc wiadomosci {i}");
                Thread.Sleep(1000);
            }
        }
    }
}