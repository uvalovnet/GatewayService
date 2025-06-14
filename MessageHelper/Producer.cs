using Confluent.Kafka;
using Entities.Interfaces;
using Entities.Requests.Account;
using Entities.Requests.Game;
using Entities.Requests.Pay;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MessageHelper
{
    public class Producer : ISender
    {
        readonly ILogger _logger;
        readonly IProducer<Null, string> _producer;

        public Producer(ILogger logger, string kafkaServer)
        {
            _logger = logger;
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaServer
            };
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task SendAsync<T>(string topicName, T message)
        {
            var serialized = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = serialized });
        }
        public Task StopAsync()
        {
            _producer?.Dispose();
            _logger.LogInformation($"{nameof(Producer)} stopped");
            return Task.CompletedTask;
        }
    }
}
