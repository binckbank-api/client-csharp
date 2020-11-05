# C# client example
This is a simple example on how to connect to the Binck realtime update platform for news, quotes and order execution.

The platform is written using [SignalR](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?tabs=visual-studio&view=aspnetcore-2.2)

After cloning or downloading this repo, make sure you add an active Bearer token in `Program.cs`, together with the account number:

```csharp
private const string AccessToken = "YOUR-ACCESS-TOKEN";
private const string AccountNumber = "YOUR-ACCOUNT-NUMBER";
```

To obtain an access token to the platform please refer to the [documentation here](https://github.com/binckbank-api/client-js#logon-to-binck-api-using-oauth2)

The example will subscribe to the news feed for the country to which the account number belongs and to the last quotes for the DAX index as an example.

```csharp
// Start the connection to the streamer
await hubConnection.StartAsync();

// Subscribe to the news feed
await hubConnection.InvokeAsync("SubscribeNews", 
   AccountNumber);

// Subscribe to an instrument quotes 
await hubConnection.InvokeAsync("SubscribeQuotes", 
   AccountNumber, 
   new[] { DaxIndex }, 
   "TopOfBook");
```
