using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMQProducer
{
    public static class FanoutExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            var ttl = new Dictionary<string, object>
            {
                {"x-message-ttl", 30000 }
            };

            channel.ExchangeDeclare("fanout-exchange", ExchangeType.Fanout, arguments: ttl);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! This is count number {count}" };
                var body = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("fanout-exchange", "account.init", null, body);
                count++;
                Thread.Sleep(1100);
            }

        }
    }
}
