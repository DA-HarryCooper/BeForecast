using System.Text.Json;

static partial class CredentialsDictionary
{
    static public Dictionary<string, string> timetastic = new() 
    {
        {"Authorization", Credentials.TIMETASTIC_AUTH}
    };
}

public class Holiday
{
    public int id { get; set; }
    public string? startDate { get; set; }
    public string? startType { get; set; }
    public string? endDate { get; set; }
    public string? endType { get; set; }
    public int userId { get; set; }
    public string? userName { get; set; }
    public int requestedById { get; set; }
    public int leaveTypeId { get; set; }
    public int duration { get; set; }
    public int deduction { get; set; }
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

public class Holidays
{
    public Holiday[]? holidays { get; set; }
}

class Timetastic : ToolInterface 
{
    public void GetHolidays()
    {
        string testJsonString = @"{
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

        Holidays holidays = JsonSerializer.Deserialize<Holidays>(testJsonString);
        Console.WriteLine(holidays.holidays[0].id);
        // Console.WriteLine($"TemperatureCelsius: {holiday?.TemperatureCelsius}");
        // Console.WriteLine($"Summary: {weatherForecast?.Summary}");

    // GET https://app.timetastic.co.uk/api/holidays
    }
}
