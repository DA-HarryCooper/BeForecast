static partial class CredentialsDictionary
{
    static public Dictionary<string, string> forecast = new() 
    {
        {"User-Agent", Credentials.USER_AGENT},
        {"Forecast-Account-ID", Credentials.FORECAST_ACCOUNT_ID},
        {"Authorization", Credentials.FORECAST_AUTH}
    };

    static public string[] getForecastEndPoints = new string[] 
        {"time_entries"}
    ;

    static public string[] postForecastEndPoints = new string[] 
        {"time_entries"}
    ;
}

class Forecast : ToolInterface
{
    
}
