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
        public delegate Task CallMethod(GeneralResponse receivedData);
        public event CallMethod onMessage;

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

        public Task StartAsync(CancellationToken cancellationToken, string topicName)
        {
            _consumer.Subscribe(topicName);
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume(cancellationToken);
                onMessage.Invoke(JsonSerializer.Deserialize<GeneralResponse>(consumeResult.Value));
            }
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            _consumer?.Dispose();
            _logger.LogInformation($"{nameof(Consumer)} stopped");
            return Task.CompletedTask;
        }
    }
}
