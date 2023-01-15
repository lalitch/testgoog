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

    [HttpGet("keywords")]
    public async Task<IActionResult> GetResult([FromQuery] string keywords)
    {

    }
  }
}