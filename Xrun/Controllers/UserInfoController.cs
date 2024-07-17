
using Microsoft.AspNetCore.Mvc;

using Xrun.Service.UserInfo.Interface;
using Xrun.Service.UserInfo.Response;
using Xrun.Service.UserInfo.Requests;

namespace Xrun.Controllers
{
    [Route("[controller]")]
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
