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

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length == 0){
            Console.WriteLine("Please specify harvest, forecast, or timetastic as the first argument");
            return;
        }

        switch (args[0]){
            case "harvest":
                await Run("https://api.harvestapp.com/v2/users/me", CredentialsDictionary.harvest);
                break;
            case "forecast":
                await Run("https://api.forecastapp.com/projects/3581108", CredentialsDictionary.forecast);
                break;
            case "timetastic":
                Console.WriteLine("Timetastic not yet implemented");
                break;
            default:
                Console.WriteLine("Invalid argument, please specify harvest, forecast, or timetastic as the first argument");
                break;
        };
    }

    static async Task Run(string url, Dictionary<string, string> creds)
    {
        HttpClient client = new();
        await HitApi(client, creds, url);
    }

    static async Task HitApi(HttpClient client, Dictionary<string, string> creds, string url)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        foreach (var (key, value) in creds) client.DefaultRequestHeaders.Add(key, value);
        var json = await client.GetStringAsync(url);
        Console.Write(json);
    }
}
