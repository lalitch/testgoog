namespace SympliDevelopment.Api.DataModels
{
    public class SearchResult
    {
        public List<SearchEntity> Results { get; set; }

        public string? Cursor {get; set;}
    }
}