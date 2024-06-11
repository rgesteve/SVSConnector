using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Connectors.Chroma;

#pragma warning disable SKEXP0001, SKEXP0010, SKEXP0020

namespace SVSConnector;

class Program
{
    static async Task Main(string[] args)
    {

	var conn = new SVSConnector();
	var data = new int[,] {{1,2},{3,4}};
	await conn.SendMessageAsync(data);

	/*
	IMemoryStore store = new ChromaMemoryStore("localhost");
	var embeddingGenerator = new  OpenAITextEmbeddingGenerationService("gpt-35turbo", "endpoint");
	SemanticTextMemory textMemory = new(store, embeddingGenerator);
	textMemory.SaveInformationAsync("collection", id: "text1", text: "test");
	MemoryQueryResult? lookup = await textMemory.GetAsync("collection", "text1");
	*/

        Console.WriteLine("Done!");
    }
}
