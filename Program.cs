namespace ClientCsharp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    public static class Program
    {
        private const string AexIndex = "eM1X1";
        private const string BearerToken = "YOUR-ACCESS-TOKEN";
        private const string AccountNumber = "YOUR-ACCOUNT-NUMBER";
        private const string StreamerUrl = "https://realtime.sandbox.binck.com/stream/v1";
        
        public static async Task Main()
        {
            if (BearerToken == "YOUR-ACCESS-TOKEN")
            {
                throw new ArgumentException("Enter a valid access token.");
            }

            HubConnection hubConnection = new HubConnectionBuilder()
                .WithUrl(StreamerUrl,
                    options =>
                        options.AccessTokenProvider = () => Task.FromResult(BearerToken)
                )
                .ConfigureLogging(logging => { logging.AddConsole(); })
                .Build();

            hubConnection.On<OrderModel>("OrderStatus", n =>
            {
                Console.WriteLine($"OrderStatus: {n.AccountNumber} ### {n.Number}");
            });

            hubConnection.On<OrderModel>("OrderModified", n =>
            {
                Console.WriteLine($"OrderModified: {n.AccountNumber} ### {n.Number}");
            });

            hubConnection.On<OrderModel>("OrderExecution", n =>
            {
                Console.WriteLine($"OrderExecution: {n.AccountNumber} ### {n.Number}");
            });

            hubConnection.On<NewsMessageModel>("News", n =>
            {
                Console.WriteLine($"News: {n.PublishedDateTime} ### {n.Headline}");
            });

            hubConnection.On<QuoteListModel>("Quote", q =>
            {
                foreach (QuoteModel quote in q.Quotes)
                {
                    Console.WriteLine($"Quote: {quote.QuoteDateTime} ### AEX {quote.QuoteType} {quote.Price}");
                }
            });

            // Start the connection to the streamer
            await hubConnection.StartAsync();

            // Subscribe to the order events feed
            await hubConnection.InvokeAsync("SubscribeOrders", 
                AccountNumber);

            // Subscribe to the news feed
            await hubConnection.InvokeAsync("SubscribeNews", 
                AccountNumber);

            // Subscribe to instrument quotes 
            await hubConnection.InvokeAsync("SubscribeQuotes", 
                AccountNumber, 
                new[] { AexIndex }, 
                "TopOfBook");

            Console.ReadLine();
        }
    }
}
