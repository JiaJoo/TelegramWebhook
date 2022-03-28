var botApiToken = Environment.GetEnvironmentVariable("BOTAPITOKEN") ?? throw new ArgumentNullException("Environment.GetEnvironmentVariable(\"BOTAPITOKEN\")");

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder, botApiToken);
var app = builder.Build();

var notificationService = app.Services.GetService<INotificationService>();

app.MapPost("/webhook/{requiredStatus}/{chatId}", [AllowAnonymous] async ([FromBody]WebhookBuildModel model, string requiredStatus, long chatId) =>
{
    await notificationService!.Notify(model, chatId, requiredStatus);
}).AllowAnonymous();

app.Run();

void RegisterServices(WebApplicationBuilder webApplicationBuilder, string botApiToken)
{
    webApplicationBuilder.Services.AddSingleton<INotificationService, NotificationService>();
    webApplicationBuilder.Services.AddSingleton<ITelegramService, TelegramService>();
    webApplicationBuilder.Services.AddBotClient(botApiToken);
}