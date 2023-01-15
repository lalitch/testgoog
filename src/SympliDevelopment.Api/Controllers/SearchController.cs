using System.Text;
using Microsoft.AspNetCore.Mvc;
using SympliDevelopment.Api.CacheProvider;

namespace SympliDevelopment.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SearchController : ControllerBase
  {
    private SearchResultsCacheProvider searchResultsCacheProvider;
    
    public SearchController(SearchResultsCacheProvider searchResultsCacheProvider)
    {
        this.searchResultsCacheProvider = searchResultsCacheProvider;
    }

    [HttpGet()]
    public async Task<IActionResult> GetResult([FromQuery] string keywords, [FromQuery] string url)
    {
      string[] words = keywords.Split(" ");

      StringBuilder sb = new StringBuilder();
      
      foreach(string word in words)
      {
        var searchResult = this.searchResultsCacheProvider.GetSearchResults(word);
        var index = searchResult.Results.Where(result => result.Url.Equals(url)).Select(result => result.Index).First();
        sb.Append(index);
        sb.Append(", ");
      }

      // TODO : return action result.
      return sb.ToString();
    }
  }
}