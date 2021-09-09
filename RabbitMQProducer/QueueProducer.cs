using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMQProducer
{
    public static class QueueProducer
    {
        public static void Publish(IModel channel)
        {
            channel.QueueDeclare("test-queue", true, false, false, null);

            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Hello! This is count number {count}" };
                var body = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("", "test-queue", null, body);
                count++;
                Thread.Sleep(1100);
            }

        }
    }
}
