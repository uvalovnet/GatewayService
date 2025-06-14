using Confluent.Kafka;
using Entities.Responses;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MessageHelper
{
    internal class Consumer
    {
        readonly ILogger _logger;
        readonly IConsumer<Null, string> _consumer;

        public Consumer(ILogger logger, string kafkaServer)
        {
            _logger = logger;
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaServer,
                GroupId = "gateway-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Null, string>(config).Build();
        }

        public async Task StartAsync<N, T>(string topicName, Func<T, N> action)
        {
            _consumer.Subscribe(topicName);
            while (true)
            {
                var consumeResult = _consumer.Consume();
                action(JsonSerializer.Deserialize<T>(consumeResult.Value));
            }
        }

        public Task StopAsync()
        {
            _consumer?.Dispose();
            _logger.LogInformation($"{nameof(Consumer)} stopped");
            return Task.CompletedTask;
        }
    }
}
