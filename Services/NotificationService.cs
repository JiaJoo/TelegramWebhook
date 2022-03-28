namespace TelegramWebhook.Services;

public class NotificationService : INotificationService
{
    private readonly ITelegramService _telegramService;

    public NotificationService(ITelegramService telegramService)
    {
        _telegramService = telegramService;
    }
    public async Task Notify(WebhookBuildModel model, long chatId, string requiredStatus)
    {
        if(requiredStatus.ToUpper() == model.Build.Status.ToUpper())
            await _telegramService.Send($"{model.Project.Name} - {model.Build.Status}", chatId);
    }
}