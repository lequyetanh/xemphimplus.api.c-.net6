using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.API.CLONE.Entities;
using POS.API.CLONE.IRepositories;
using POS.API.CLONE.Model;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace POS.API.CLONE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
       private readonly IConfiguration _configuration;
        private readonly UserIRepositories _userRepositories;

        public UserController(UserIRepositories userRepositories, IConfiguration configuration)
        {
            _userRepositories = userRepositories;
            _configuration = configuration;
        }

        [HttpGet("list")]
        public async Task<IActionResult> getListUser()
        {
            try
            {
                var user = await this._userRepositories.getListUser();

                return Ok(new ResponseSingleContentModel<List<User_Entity>>
                {
                    StatusCode = 200,
                    Message = "Lấy danh sách bản ghi thành công",
                    Data = user
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
        public async Task<IActionResult> getUserDetail(long user_id)
        {
            try
            {
                var user = await _userRepositories.getUserDetail(user_id);
                System.Console.WriteLine(user);
                return Ok(new ResponseSingleContentModel<User_Entity>
                {
                    StatusCode = 200,
                    Message = "Lấy thông tin chi tiết bản ghi thành công",
                    Data = user
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
        public async Task<IActionResult> userCreate([FromBody] User_Entity User)
        {
            try
            {
                var user = await this._userRepositories.userCreate(User);

                return Ok(new ResponseSingleContentModel<User_Entity>
                {
                    StatusCode = 200,
                    Message = "Thêm mới bản ghi thành công",
                    Data = User
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
        public async Task<IActionResult> UserModify([FromBody] User_Entity userDetail)
        {
            try
            {
                var user = await this._userRepositories.userModify(userDetail);
                return Ok(new ResponseSingleContentModel<User_Entity>
                {
                    StatusCode = 200,
                    Message = "Chỉnh sửa bản ghi thành công",
                    Data = user
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
        public async Task<IActionResult> deleteUser(long user_id)
        {
            try
            {
                var user = await this._userRepositories.userDelete(user_id);
                return Ok(new ResponseSingleContentModel<User_Entity>
                {
                    StatusCode = 200,
                    Message = "Xóa bản ghi thành công",
                    Data = user
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
