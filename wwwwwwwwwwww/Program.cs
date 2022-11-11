using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace wwwwwwwwwwww
{
    internal class Program
    {
        private const string baseUrl = @"http://api.weatherstack.com/current";
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "ConsoleApp");

            HttpResponseMessage response = await client.GetAsync(baseUrl);

            string content = await response.Content.ReadAsStringAsync();

            var jsonSerializerOption = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            string TOKEN = "";

            using var cts = new CancellationTokenSource();

            var botClient = new TelegramBotClient(TOKEN);

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };


            botClient.StartReceiving(updateHandler : HandleUpdate,
                cancellationToken : cts.Token,
                receiverOptions : receiverOptions,
                pollingErrorHandler : HandlePollingErrorAsync);




        static Task HandlePollingErrorAsync(
        ITelegramBotClient botClient,
        Exception exception,
        CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }

            InlineKeyboardMarkup inlineKeyboardButton = new(new[]
            {
            new[]
            {
                InlineKeyboardButton.WithCallbackData(text:"button",callbackData:"khbh"),
                InlineKeyboardButton.WithCallbackData(text:"buttttton",callbackData:"kebhb")
            },

           });
        }
    }
}