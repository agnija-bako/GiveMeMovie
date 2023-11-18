using System.Net;
using GiveMeMovie.DataModels;
using GiveMeMovie.Services.ApiHelper.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GiveMeMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangesController : ControllerBase
    {
        private readonly IGetMovieChangesList _getMovieChangesList;

        public ChangesController(IGetMovieChangesList getMovieChangesList)
        {
            _getMovieChangesList = getMovieChangesList;
        }

        [HttpGet]
        [Route(nameof(GetChangesMoviesList))]
        [ProducesResponseType(typeof(MovieChanges), (int)HttpStatusCode.OK)]
        public async ValueTask<IActionResult> GetChangesMoviesList()
        {
            MovieChanges? list = await _getMovieChangesList.GetMovieChanges();
            return list == null ? throw new Exception("Couldn't get the changes") : Ok(list);
        }
    }
}