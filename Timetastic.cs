using System.Text.Json;

static partial class CredentialsDictionary
{
    static public Dictionary<string, string> timetastic = new() 
    {
        {"Authorization", Credentials.TIMETASTIC_AUTH}
    };
}

struct Holiday
{
    public int id;
    public string startDate;
    public string startType;
    public string endDate;
    public string endType;
    public int userId;
    public string userName;
    public int requestedById;
    public int leaveTypeId;
    public int duration;
    public int deduction;
    public int actionerId;
    public string createdAt;
    public string updatedAt;
    public string reason;
    public string declineReason;
    public string status;
    public bool autoApproved;
    public string bookingUnit;
    public string leaveType;
}

struct Holidays
{
    public Holiday[] holidays;
}

class Timetastic : ToolInterface 
{
    static public void GetHolidays()
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
            }]}";

        Holidays holidays = JsonSerializer.Deserialize<Holidays>(testJsonString);
        Console.WriteLine(holidays.holidays[0]);
        // Console.WriteLine($"TemperatureCelsius: {holiday?.TemperatureCelsius}");
        // Console.WriteLine($"Summary: {weatherForecast?.Summary}");

    // GET https://app.timetastic.co.uk/api/holidays
    }
}
