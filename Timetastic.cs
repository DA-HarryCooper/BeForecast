using System.Text.Json;

static partial class CredentialsDictionary
{
    static public Dictionary<string, string> timetastic = new() 
    {
        {"Authorization", Credentials.TIMETASTIC_AUTH}
    };

    static public string dummyData = @"{
            ""holidays"": [
            {
                ""id"": 101010,
                ""startDate"": ""2019-04-11T00:00:00"",
                ""startType"": ""Morning"",
                ""endDate"": ""2019-04-16T00:00:00"",
                ""endType"": ""Afternoon"",
                ""userId"": 121212,
                ""userName"": ""Gareth Terrace"",
                ""requestedById"": 121212,
                ""leaveTypeId"": 100,
                ""duration"": 6,
                ""deduction"": 4,
                ""actionerId"": 121212,
                ""createdAt"": ""2018-10-07T20:05:02"",
                ""updatedAt"": ""2018-10-07T20:05:10"",
                ""reason"": ""I'm not working today!"",
                ""declineReason"": null,
                ""status"": ""Approved"",
                ""autoApproved"": false,
                ""bookingUnit"": ""Days"",
                ""leaveType"": ""Annual Leave""
            },
            {
                ""id"": 101010,
                ""startDate"": ""2019-04-11T00:00:00"",
                ""startType"": ""Morning"",
                ""endDate"": ""2019-04-16T00:00:00"",
                ""endType"": ""Afternoon"",
                ""userId"": 121212,
                ""userName"": ""Gareth Terrace"",
                ""requestedById"": 121212,
                ""leaveTypeId"": 100,
                ""duration"": 6,
                ""deduction"": 4,
                ""actionerId"": 121212,
                ""createdAt"": ""2018-10-07T20:05:02"",
                ""updatedAt"": ""2018-10-07T20:05:10"",
                ""reason"": ""I'm not working today!"",
                ""declineReason"": null,
                ""status"": ""Approved"",
                ""autoApproved"": false,
                ""bookingUnit"": ""Days"",
                ""leaveType"": ""Annual Leave""
            }]}";
}

struct Holiday
{
    public Int32 id { get; set; }
    public string? startDate { get; set; }
    public string? startType { get; set; }
    public string? endDate { get; set; }
    public string? endType { get; set; }
    public int userId { get; set; }
    public string? userName { get; set; }
    public int requestedById { get; set; }
    public int leaveTypeId { get; set; }
    public float duration { get; set; }
    public float deduction { get; set; }
    public int actionerId { get; set; }
    public string? createdAt { get; set; }
    public string? updatedAt { get; set; }
    public string? reason { get; set; }
    public string? declineReason { get; set; }
    public string? status { get; set; }
    public bool autoApproved { get; set; }
    public string? bookingUnit { get; set; }
    public string? leaveType { get; set; }
}

struct Holidays
{
    public Holiday[]? holidays { get; set; }
}

class Timetastic : ToolInterface 
{
    public override async Task DoWork(HttpClient client, Dictionary<string, string> creds, string url)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        foreach (var (key, value) in creds) client.DefaultRequestHeaders.Add(key, value);
        var json = await client.GetStringAsync(url);
        ProcessHolidays(json);
    }

    public void ProcessHolidays(string json)
    {
        Holidays holidays = JsonSerializer.Deserialize<Holidays>(json);
        Console.WriteLine(holidays.holidays[0].id);
    }
}
