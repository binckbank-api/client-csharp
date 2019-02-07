namespace ClientCsharp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR.Client;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        private const string AEXIndex = "eM1X1";
        private const string AccessToken = "YOUR-ACCESS-TOKEN";
        private const string AccountNumber = "YOUR-ACCOUNT-NUMBER";
        private const string StreamerUrl = "https://realtime.sandbox.binck.com/stream/v1";
        
        public static async Task Main(string[] args)
        {
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(StreamerUrl,
                    options =>
                        options.AccessTokenProvider = () => Task.FromResult(AccessToken)
                )
                .ConfigureLogging(logging => { logging.AddConsole(); })
                .Build();


            hubConnection.On<NewsHead>("News", n =>
            {
                Console.WriteLine($"{n.Dt} ### {n.Head}");
            });

            hubConnection.On<InstrumentQuote>("Quote", q =>
            {
                q.Qt.ForEach(x =>
                        Console.WriteLine($"{x.Dt} ### AEX {x.Typ} {x.Prc}"));
            });

            // Start the connection to the streamer
            await hubConnection.StartAsync();

            // Subscribe to the news feed
            await hubConnection.InvokeAsync("SubscribeNews", 
                AccountNumber);

            // Subscribe to an instrument quotes 
            await hubConnection.InvokeAsync("SubscribeQuotes", 
                AccountNumber, 
                new[] { AEXIndex }, 
                "TopOfBook");

            Console.ReadLine();
        }
    }
}
