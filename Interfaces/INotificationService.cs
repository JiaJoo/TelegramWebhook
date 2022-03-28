namespace TelegramWebhook.Interfaces;

public interface INotificationService
{
    Task Notify(WebhookBuildModel model, long chatId, string requiredStatus);
}