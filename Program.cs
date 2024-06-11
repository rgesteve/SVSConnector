using System.Net.Http;

namespace SVSConnector;

class Program
{
    static async Task Main(string[] args)
    {
	var uri = new Uri("http://localhost:5000/control/ping");
	var client = new HttpClient();

	HttpResponseMessage response =
          await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));

	string content = new StreamReader(response.Content.ReadAsStream()).ReadToEnd();

        Console.WriteLine($"Received the response {content}");
        Console.WriteLine("Done!");
    }
}
