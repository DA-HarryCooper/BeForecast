static partial class CredentialsDictionary
{
    static public Dictionary<string, string> harvest = new() {
        {"User-Agent", Credentials.USER_AGENT},
        {"Harvest-Account-ID", Credentials.HARVEST_ACCOUNT_ID},
        {"Authorization", Credentials.HARVEST_AUTH}
    };

    static public string[] getHarvestEndPoints = new string[] 
        {"time_entries"}
    ;

    static public string[] postHarvestEndPoints = new string[] 
        {"time_entries"}
    ;
}

class Harvest : ToolInterface
{
    
}
