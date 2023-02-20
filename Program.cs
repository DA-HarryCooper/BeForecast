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
        await Run();
    }

    static async Task Run()
    {
        HttpClient harvestClient = new();
        HttpClient forecastClient = new();
        await HitApi(harvestClient, CredentialsDictionary.harvest, "https://api.harvestapp.com/v2/users/me");
        await HitApi(forecastClient, CredentialsDictionary.forecast, "https://api.forecastapp.com/projects/3581108");
    }

    static async Task HitApi(HttpClient client, Dictionary<string, string> creds, string url)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        foreach (var (key, value) in creds) client.DefaultRequestHeaders.Add(key, value);
        var json = await client.GetStringAsync(url);
        Console.Write(json);
    }
}
