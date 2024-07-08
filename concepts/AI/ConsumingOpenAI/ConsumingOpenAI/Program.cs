using Newtonsoft.Json;

var client = new HttpClient();

client.DefaultRequestHeaders.Add("Authorization", "Bearer ");

var json = JsonConvert.SerializeObject(new { model = "gpt-3.5-turbo"}, );