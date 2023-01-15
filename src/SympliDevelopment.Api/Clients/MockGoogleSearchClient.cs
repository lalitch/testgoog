using Microsoft.AspNetCore.Mvc;
using SympliDevelopment.Api.DataModels;

namespace SympliDevelopment.Api.Clients
{
  public class MockGoogleSearchClient : ISearchClient
  {
     private Dictionary<string, List<SearchEntity>> mockSearchResults = new Dictionary<string, List<SearchEntity>>
     {
        { 
            "e-settlements",
            new List<SearchEntity>
            {
                new SearchEntity { Index = 2, Title = "Online Settlements", Url = "https://www.sympli.com.au/" },
                new SearchEntity { Index = 2, Title = "Online Settlements", Url = "https://www.sympli.com.au/" },
                new SearchEntity { Index = 2, Title = "Online Settlements", Url = "https://www.sympli.com.au/" },
                new SearchEntity { Index = 5, Title = "Online Settlements Firm", Url = "https://www.es.com.au/" },
                new SearchEntity { Index = 7, Title = "Online Settlements Company", Url = "https://www.es2.com.au/" }
            } 
        }
     };

     public SearchResult GetSearchResults(string keyword, int top, string? cursor = null)
     {
        if(mockSearchResults.TryGetValue(keyword, out List<SearchEntity> searchEntities)) {
            searchEntities = new List<SearchEntity>();
        }

        return new SearchResult
        {
            Results = searchEntities;
        };
     }
  }
}