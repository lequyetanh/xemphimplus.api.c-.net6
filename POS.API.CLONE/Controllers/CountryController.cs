using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;
using POS.API.CLONE.Model;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace POS.API.CLONE.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly CountryIRepositories _countryRepositories;

        public CountryController(CountryIRepositories countryRepositories, IConfiguration configuration)
        {
            _countryRepositories = countryRepositories;
            _configuration = configuration;
        }

        [HttpGet("list")]
        public async Task<IActionResult> getListCountry()
        {
            try
            {
                var country = await this._countryRepositories.getListCountry();

                return Ok(new ResponseSingleContentModel<List<Country>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách bản ghi thành công",
                    Data = country
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
        public async Task<IActionResult> getCountryDetail(long country_id)
        {
            try
            {
                var country = await _countryRepositories.getCountryDetail(country_id);
                System.Console.WriteLine(country);
                return Ok(new ResponseSingleContentModel<Country>
                {
                    StatusCode = 200,
                    Message = "Lấy thông tin chi tiết bản ghi thành công",
                    Data = country
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
        public async Task<IActionResult> CountryCreate([FromBody] Country Country)
        {
            try
            {
                var country = await this._countryRepositories.CountryCreate(Country);

                return Ok(new ResponseSingleContentModel<Country>
                {
                    StatusCode = 200,
                    Message = "Thêm mới bản ghi thành công",
                    Data = Country
                });
            }
            catch (Exception error)
            {
                return Ok(new ResponseSingleContentModel<IResponseData>
                {
                    StatusCode = 500,
                    Message = "Có lỗi trong quá trình xử lý",
                    Data = null
                });
            }
        }

        [HttpPost("modify")]
        public async Task<IActionResult> UserModify([FromBody] Country countryDetail)
        {
            try
            {
                var country = await this._countryRepositories.countryModify(countryDetail);
                return Ok(new ResponseSingleContentModel<Country>
                {
                    StatusCode = 200,
                    Message = "Chỉnh sửa bản ghi thành công",
                    Data = country
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

        [HttpDelete("delete")]
        public async Task<IActionResult> deleteCountry(long country_id)
        {
            try
            {
                var country = await this._countryRepositories.countryDelete(country_id);
                return Ok(new ResponseSingleContentModel<Country>
                {
                    StatusCode = 200,
                    Message = "Xóa bản ghi thành công",
                    Data = country
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
