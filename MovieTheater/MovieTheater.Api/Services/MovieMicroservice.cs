using Flurl.Http;
using MovieTheater.Api.Models;
using Newtonsoft.Json;

namespace MovieTheater.Api.Services;

public class MovieMicroservice
{
    private readonly string _baseUrl = "https://api.themoviedb.org/3";
    private readonly string _apiKey = "df9e102b6b13698d0612a40e557fb317";

    public async Task<IEnumerable<ExternalMovieModel>> FetchMovies()
    {
        var request = _baseUrl 
                      + "/discover/movie?primary_release_date.gte=2022-09-15&primary_release_date.lte=2022-10-22&api_key="
                      + _apiKey;
        var response = await request
            .GetAsync();
        var content = await response.ResponseMessage.Content.ReadAsStringAsync();
        var movies = JsonConvert.DeserializeObject<ExternalResponse>(content);
        
        return movies.Results;
    }
}