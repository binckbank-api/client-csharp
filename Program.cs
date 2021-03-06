﻿namespace ClientCsharp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    public static class Program
    {
        private const string DaxIndex = "b6OQR";
        private const string BearerToken = "YOUR-ACCESS-TOKEN"; // Only token, no prefix "Bearer "
        private const string AccountNumber = "YOUR-ACCOUNT-NUMBER"; // Not the IBAN, but the number in the GET /accounts response
        private const string StreamerUrl = "https://realtime.sandbox.binck.com/stream/v1";  // For production use https://realtime.binck.com/stream/v1

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
                    Console.WriteLine($"Quote: {quote.QuoteDateTime} ### DAX {quote.QuoteType} {quote.Price}");
                }
            });

            // Start the connection to the streamer
            try
            {
                await hubConnection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                Console.WriteLine(
                    "Connection is not active. Per token only one session is allowed. Could that be the reason?");
            }
            else
            {
                try
                {
                    // Subscribe to the order events feed
                    await hubConnection.InvokeAsync("SubscribeOrders",
                        AccountNumber);

                    // Subscribe to the news feed
                    await hubConnection.InvokeAsync("SubscribeNews",
                        AccountNumber);

                    // Subscribe to instrument quotes 
                    await hubConnection.InvokeAsync("SubscribeQuotes",
                        AccountNumber,
                        new[] { DaxIndex },
                        "TopOfBook");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
