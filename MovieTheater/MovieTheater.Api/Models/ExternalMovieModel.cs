using Newtonsoft.Json;

namespace MovieTheater.Api.Models;

public class ExternalMovieModel
{
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("overview")]
    public string Description { get; set; }

    [JsonProperty("poster_path")]
    public string Poster { get; set; }

    [JsonProperty("release_date")]
    public DateTime DateReleased { get; set; }
}