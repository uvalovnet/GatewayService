using Confluent.Kafka;
using Entities.Commands.Account;
using Entities.Commands.Game;
using Entities.Commands.Pay;
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

        public async Task SendAsync(string topicName, RegAndAuthCommand message)
        {
            var serialized = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = serialized });
        }
        public async Task SendAsync(string topicName, GameActionCommand message)
        {
            var serialized = JsonSerializer.Serialize(message);
            await _producer.ProduceAsync(topicName, new Message<Null, string> { Value = serialized });
        }
        public async Task SendAsync(string topicName, BillActionCommand message)
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
