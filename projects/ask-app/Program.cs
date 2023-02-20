using System.Text;

if (args.Length > 0)
{
    HttpClient client = new HttpClient();

    client.DefaultRequestHeaders.Add("authorization", "Bearer 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"); // -> API key: not a good

    var content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \""+ args[0] +"\", \"temperature\": 1, \"max_tokens\": 100}", Encoding.UTF8, "application/json");

    HttpResponseMessage response = 
}
else
{
    Console.WriteLine("===> você precisa escrever algo...");
}