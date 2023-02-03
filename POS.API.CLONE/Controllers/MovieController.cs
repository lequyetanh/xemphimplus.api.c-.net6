using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;
using POS.API.CLONE.Model;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace POS.API.CLONE.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly MovieIRepositories _movieRepositories;

        public MovieController(MovieIRepositories movieRepositories, IConfiguration configuration)
        {
            _movieRepositories = movieRepositories;
            _configuration = configuration;
        }

        [HttpGet("list")]
        public async Task<IActionResult> getListMovie()
        {
            try
            {
                var movie = await this._movieRepositories.getListMovie();

                return Ok(new ResponseSingleContentModel<List<Movie_Entity>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách bản ghi thành công",
                    Data = movie
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xảy ra trong quá trình xử lý",
                    Data = null
                });
            }
        }

        [HttpGet("detail")]
        public async Task<IActionResult> getMovieDetail(long movie_id)
        {
            try
            {
                var movie = await _movieRepositories.getMovieDetail(movie_id);
                System.Console.WriteLine(movie);
                return Ok(new ResponseSingleContentModel<Movie_Entity>
                {
                    StatusCode = 200,
                    Message = "Lấy thông tin chi tiết bản ghi thành công",
                    Data = movie
                });
            }
            catch (Exception error)
            {
                System.Console.WriteLine(error.InnerException);
                return Ok(new ResponseSingleContentModel<string>
                {
                    StatusCode = 500,
                    Message = "Có lỗi xảy ra trong quá trình lấy chi tiết bản ghi",
                    Data = string.Empty
                });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> movieCreate([FromBody] Movie_Entity Movie)
        {
            try
            {
                var movie = await this._movieRepositories.movieCreate(Movie);

                return Ok(new ResponseSingleContentModel<Movie_Entity>
                {
                    StatusCode = 200,
                    Message = "Thêm mới bản ghi thành công",
                    Data = Movie
                });
            }
            catch (Exception error)
            {
                System.Console.WriteLine(error.Message);
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }

        [HttpPost("modify")]
        public async Task<IActionResult> MovieModify([FromBody] Movie_Entity movieDetail)
        {
            try
            {
                var movie = await this._movieRepositories.movieModify(movieDetail);
                return Ok(new ResponseSingleContentModel<Movie_Entity>
                {
                    StatusCode = 200,
                    Message = "Chỉnh sửa bản ghi thành công",
                    Data = movie
                });
            }
            catch (Exception error)
            {
                System.Console.WriteLine(error.Message);
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> deleteMovie(long movie_id)
        {
            try
            {
                var movie = await this._movieRepositories.movieDelete(movie_id);
                return Ok(new ResponseSingleContentModel<Movie_Entity>
                {
                    StatusCode = 200,
                    Message = "Xóa bản ghi thành công",
                    Data = movie
                });
            }
            catch (Exception)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }
    }
}
