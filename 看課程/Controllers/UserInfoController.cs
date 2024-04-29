
using Microsoft.AspNetCore.Mvc;

using 看課程.Service.UserInfo.Interface;
using 看課程.Service.UserInfo.Response;
using 看課程.Service.UserInfo.Requests;

namespace 看課程.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userinfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userinfoService = userInfoService;
        }



        [HttpGet("UserInfoCheck")]
        public async Task<IActionResult> UserInfoCheck([FromQuery] IdReq idReq)
        {
            UserInfoCheckRes result = await _userinfoService.verifyUserInfo(idReq);
            return result.Success ? Ok(result) : NotFound(result);

        }

    }
}
