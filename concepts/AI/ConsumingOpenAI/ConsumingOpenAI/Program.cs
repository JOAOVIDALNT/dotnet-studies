using Newtonsoft.Json;

var client = new HttpClient();

client.DefaultRequestHeaders.Add("Authorization", "Bearer sk-proj-HLksdv7EROj2MTufqhQsT3BlbkFJHcUhANXEzscGxYFfGQrL");

var json = JsonConvert.SerializeObject(new { model = "gpt-3.5-turbo"}, );