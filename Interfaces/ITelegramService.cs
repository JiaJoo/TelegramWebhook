namespace TelegramWebhook.Interfaces;

public interface ITelegramService
{
    Task Send(string message, long chatId);
}