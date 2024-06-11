using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Text;

namespace SVSConnector;

#pragma warning disable SKEXP0001

/// <summary>
/// An implementation of <see cref="IMemoryStore" /> for Intel's Scalable Vector Search.
/// </summary>
public class SVSMemoryStore : IMemoryStore
{
    public SVSMemoryStore(string endpoint, ILoggerFactory? loggerFactory = null)
        : this(new SVSConnector(endpoint, loggerFactory), loggerFactory)
    {
    }

    public SVSMemoryStore(SVSConnector conn, ILoggerFactory? loggerFactory)
    {
    }

    public async Task CreateCollectionAsync(string collectionName, CancellationToken cancellationToken = default)
    {
    }

    public async Task DeleteCollectionAsync(string collectionName, CancellationToken cancellationToken = default)
    {
    }

    public async Task<bool> DoesCollectionExistAsync(string collectionName, CancellationToken cancellationToken = default)
    {
    #if false
        Verify.NotNullOrWhiteSpace(collectionName);

        var collection = await this.GetCollectionAsync(collectionName, cancellationToken).ConfigureAwait(false);

        return collection is not null;
	#else
	return false;
	#endif
    }

    public async Task<MemoryRecord?> GetAsync(string collectionName, string key, bool withEmbedding = false, CancellationToken cancellationToken = default)
    {
    #if false
        return await this.GetBatchAsync(collectionName, [key], withEmbedding, cancellationToken)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
	    #else
	    return  null;
	    #endif
    }

    public async IAsyncEnumerable<MemoryRecord> GetBatchAsync(string collectionName, IEnumerable<string> keys, bool withEmbeddings = false, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
	yield return null;
    }

    public IAsyncEnumerable<string> GetCollectionsAsync(CancellationToken cancellationToken = default)
    {
	return null;
    }

    public async Task<(MemoryRecord, double)?> GetNearestMatchAsync(string collectionName, ReadOnlyMemory<float> embedding, double minRelevanceScore = 0, bool withEmbedding = false, CancellationToken cancellationToken = default)
    {
    #if false
        var results = this.GetNearestMatchesAsync(
            collectionName,
            embedding,
            minRelevanceScore: minRelevanceScore,
            limit: 1,
            withEmbeddings: withEmbedding,
            cancellationToken: cancellationToken);

        (MemoryRecord memoryRecord, double similarityScore) = await results.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);

        return (memoryRecord, similarityScore);
	#else
	return null;
	#endif
    }

    public async IAsyncEnumerable<(MemoryRecord, double)> GetNearestMatchesAsync(string collectionName, ReadOnlyMemory<float> embedding, int limit, double minRelevanceScore = 0, bool withEmbeddings = false, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
	yield return (null,-0.0);
    }

    public async Task RemoveAsync(string collectionName, string key, CancellationToken cancellationToken = default)
    {
        #if false
        await this.RemoveBatchAsync(collectionName, [key], cancellationToken).ConfigureAwait(false);
	#endif
    }

    public async Task RemoveBatchAsync(string collectionName, IEnumerable<string> keys, CancellationToken cancellationToken = default)
    {
	// NOT IMPLEMENTED
    }

    public async Task<string> UpsertAsync(string collectionName, MemoryRecord record, CancellationToken cancellationToken = default)
    {
    #if false
        Verify.NotNullOrWhiteSpace(collectionName);

        var key = await this.UpsertBatchAsync(collectionName, [record], cancellationToken)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        return key ?? string.Empty;
	#else
	return null;
	#endif
    }

    public async IAsyncEnumerable<string> UpsertBatchAsync(string collectionName, IEnumerable<MemoryRecord> records, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
	yield return null;
    }
    
    private readonly ILogger _logger;
    private readonly SVSConnector _svsClient;
}
