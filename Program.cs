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
                Harvest harvest = new();
                await harvest.Run("https://api.harvestapp.com/v2/users/me", CredentialsDictionary.harvest);
                break;
            case "forecast":
                Forecast forecast = new();
                await forecast.Run("https://api.forecastapp.com/people", CredentialsDictionary.forecast);
                break;
            case "timetastic":
                Timetastic timetastic = new Timetastic();
                await timetastic.Run("https://app.timetastic.co.uk/api/holidays", CredentialsDictionary.timetastic);
                break;
            default:
                Console.WriteLine("Invalid argument, please specify harvest, forecast, or timetastic as the first argument");
                break;
        };
    }
}

class ToolInterface 
{
    public async Task Run(string url, Dictionary<string, string> creds)
    {
        HttpClient client = new();
        await DoWork(client, creds, url);
    }

    public virtual async Task DoWork(HttpClient client, Dictionary<string, string> creds, string url)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        foreach (var (key, value) in creds) client.DefaultRequestHeaders.Add(key, value);
        var json = await client.GetStringAsync(url);
        
    }
}
