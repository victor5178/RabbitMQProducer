using System;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQProducer
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Create a connection factory
            var factory = new ConnectionFactory 
            {
            Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            //Create a channel
            using var channel = connection.CreateModel();
            //QueueProducer.Publish(channel);
            //DirectExchangePublisher.Publish(channel);
            //TopicExchangeProducer.Publish(channel);
            //HeaderExchangePublisher.Publish(channel);
            FanoutExchangePublisher.Publish(channel);
        }
    }
}
