using Entities.Interfaces;
using GatewayService.Hubs;
using GatewayService.Interfaces;
using GatewayService.Logger;
using GatewayService.Services;
using MessageHelper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using static Confluent.Kafka.ConfigPropertyNames;

var builder = WebApplication.CreateBuilder(args);
var Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

string kafkaServer = Configuration["KafkaServer"];

ILoggerFactory loggerFactory = new LoggerFactory().AddFile(Configuration["LogFile"]);
ILogger logger = loggerFactory.CreateLogger<Program>();

builder.Services.AddControllers();
builder.Services.AddSignalR((hubOptions =>
{
    hubOptions.EnableDetailedErrors = true;
}));

builder.Services.AddSingleton<ISender, MessageHelper.Producer>(_ => new MessageHelper.Producer(logger, kafkaServer));
builder.Services.AddSingleton<ICallbackSeparator, CallbackSeparator>(_ => new CallbackSeparator(logger, kafkaServer));
builder.Services.AddSingleton<IAccountCallbackService, AccountCallbackService>
    (x => new AccountCallbackService(x.GetRequiredService<ICallbackSeparator>(), x.GetRequiredService<IHubContext<AccountHub>>()));
builder.Services.AddSingleton<IGameCallbackService, GameCallbackService>
    (x => new GameCallbackService(x.GetRequiredService<ICallbackSeparator>(), x.GetRequiredService<IHubContext<GameHub>>()));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(Configuration["FrontAddress"])
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

//app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<AccountHub>("/account");
    endpoints.MapHub<GameHub>("/game");
    endpoints.MapHub<PayHub>("/pay");
});

//Starting background callback services
app.Services.GetService<IAccountCallbackService>().Starter();
app.Services.GetService<IGameCallbackService>().Starter();
new Thread(() => { app.Services.GetService<ICallbackSeparator>().Subscribe(); }).Start();

logger.LogInformation("Start at " + DateTime.Now);
app.Run();

