using SympliDevelopment.Api.DataModels;

namespace SympliDevelopment.Api.CacheProvider
{
  public class SearchResultsCacheProvider
  {
     private TimeSpan cacheExpirationTime { get; set; }

     private ISearchClient searchClient;

     public SearchResultsCacheProvider(ISearchClient searchClient, TimeSpan cacheExpirationTime)
     {
        this.searchClient = searchClient;
        this.cacheExpirationTime = cacheExpirationTime;
     }

     private Dictionary<string, CacheEntity> cachedResults = new Dictionary<string, CacheEntity>();

     public SearchResult GetSearchResults(string keyword, int top, string? cursor = null)
     {
        if(!cachedResults.TryGetValue(keyword, out CacheEntity? cacheEntity) || this.isCachedEntityExpired(cacheEntity)) {
            var searchResult = this.searchClient.GetSearchResults();

            // TODO: Check if C# cache throws exception if entry already exists in the cache or just updates the existing entry.
            cachedResults.Add(keyword, new CacheEntity() { SearchResult = searchResult, CreationTime = DateTime.UtcNow });

            return searchResult;
        }

        return cacheEntity.SearchResult;
     }

     private bool isCachedEntityExpired(CacheEntity cacheEntity)
     {
        return cacheEntity.CreationTime < DateTime.UtcNow - this.cacheExpirationTime;
     }
  }
}