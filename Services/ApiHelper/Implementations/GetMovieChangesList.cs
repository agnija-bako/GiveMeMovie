using System.Text.Json;
using GiveMeMovie.DataModels;
using GiveMeMovie.Services.ApiHelper.Interfaces;

namespace GiveMeMovie.Services.ApiHelper.Implementations
{
    public class GetMovieChangesList : IGetMovieChangesList
    {
        private readonly IHttpClientFactory _factory;

        public GetMovieChangesList(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<MovieChanges> GetMovieChanges()
        {
            using var client = _factory.CreateClient("externalApiClient");
            var response = await client.GetAsync("3/movie/changes");
            var content = await response.Content.ReadAsStringAsync();
            var changes = JsonSerializer.Deserialize<MovieChanges>(content);

            return changes;
        }
    }
}