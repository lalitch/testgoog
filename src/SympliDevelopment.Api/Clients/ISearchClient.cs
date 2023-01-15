using Microsoft.AspNetCore.Mvc;
using SympliDevelopment.Api.DataModels;

namespace SympliDevelopment.Api.Clients
{
  public interface ISearchClient
  {
     SearchResult GetSearchResults(string keyword, int top, string? cursor = null);
  }
}