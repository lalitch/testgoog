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

     public SearchResult GetSearchResults(string keyword)
     {
        if(cachedResults.TryGetValue(keyword, out CacheEntity? cacheEntity) && this.isCachedEntityValid(cacheEntity)) {
            return cacheEntity.SearchResult;
        }

        // Fetching top 100 results as mentioned.
        var searchResult = this.searchClient.GetSearchResults(keyword, 100);
        cachedResults[keyword] = new CacheEntity() { SearchResult = searchResult, CreationTime = DateTime.UtcNow };

        return searchResult;
     }

     private bool isCachedEntityValid(CacheEntity cacheEntity)
     {
        return cacheEntity.CreationTime >= (DateTime.UtcNow - this.cacheExpirationTime);
     }
  }
}