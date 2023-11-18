using GiveMeMovie.DataModels;

namespace GiveMeMovie.Services.ApiHelper.Interfaces
{
    public interface IGetMovieChangesList
    {
        Task<MovieChanges> GetMovieChanges();
    }
}
