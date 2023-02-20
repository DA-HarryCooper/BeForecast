HttpClient harvestClient = new();
HttpClient forecastClient = new();
harvestClient.DefaultRequestHeaders.Accept.Clear();
forecastClient.DefaultRequestHeaders.Accept.Clear();
foreach (var (key, value) in CredentialsDictionary.harvest) harvestClient.DefaultRequestHeaders.Add(key, value);
foreach (var (key, value) in CredentialsDictionary.forecast) forecastClient.DefaultRequestHeaders.Add(key, value);
await ProcessRepositoriesAsync(harvestClient, "https://api.harvestapp.com/v2/users/me");
await ProcessRepositoriesAsync(forecastClient, "https://api.forecastapp.com/projects/3581108");

static async Task ProcessRepositoriesAsync(HttpClient client, string url)
{
    Console.WriteLine("ProcessRepositoriesAsync");
    var json = await client.GetStringAsync(url);
    Console.Write(json);
}

static class CredentialsDictionary
{
    static public Dictionary<string, string> harvest = new() {
        {"User-Agent", Credentials.USER_AGENT},
        {"Harvest-Account-ID", Credentials.HARVEST_ACCOUNT_ID},
        {"Authorization", Credentials.AUTHORIZATION}
    };

    static public Dictionary<string, string> forecast = new() {
        {"User-Agent", Credentials.USER_AGENT},
        {"Forecast-Account-ID", Credentials.FORECAST_ACCOUNT_ID},
        {"Authorization", Credentials.AUTHORIZATION}
    };
}

// class Program
// {
//     static void Main(string[] args)
//     {
//         Run();
//     }

//     static async void Run()
//     {
//         Console.WriteLine("Run");
//     }
// }
