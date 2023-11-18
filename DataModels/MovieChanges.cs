using System.Text.Json.Serialization;

namespace GiveMeMovie.DataModels;

public class MovieChanges
{
    [JsonPropertyName("results")] public List<Result> Results { get; set; }
    //[JsonPropertyName("page")] public int Page { get; set; }
    //[JsonPropertyName("total_pages")] public int TotalPages { get; set; }
    //[JsonPropertyName("total_results")] public int TotalResults { get; set; }
}

public class Result
{
    [JsonPropertyName("id")] public int? Id { get; set; }
    [JsonPropertyName("adult")] public bool? Adult { get; set; }
}