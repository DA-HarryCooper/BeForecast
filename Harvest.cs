// using System.Net.Http;

// static public class RunHarvest
// {
//     static public async void Run()
//     {
//         using HttpClient harvestClient = new();
//         harvestClient.DefaultRequestHeaders.Accept.Clear();
        
//         foreach (var (key, value) in Credentials.harvest) harvestClient.DefaultRequestHeaders.Add(key, value);

//         await Credentials.ProcessRepositoriesAsync(harvestClient, "https://api.harvestapp.com/v2/projects");
//     }
// }
