using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitor;


CreateHostBuilder(args).Build().Run();
    Console.ReadKey();


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host
        .CreateDefaultBuilder(args)
        .ConfigureServices((context, collection) =>
            collection.AddHostedService<KafkaConsumerService>());
    
