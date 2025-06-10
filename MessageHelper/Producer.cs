using Confluent.Kafka;
using Entities.Requests.Account;
using Entities.Requests.Game;
using Entities.Requests.Pay;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MessageHelper
{
    internal class Producer
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

        public async Task SendAsync(string topicName, RegAndAuthRequest message)
        {
            var serialized = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = serialized });
        }
        public async Task SendAsync(string topicName, GameActionRequest message)
        {
            var serialized = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = serialized });
        }
        public async Task SendAsync(string topicName, BillActionRequest message)
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
