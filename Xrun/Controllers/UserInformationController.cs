
using Microsoft.AspNetCore.Mvc;

using Xrun.Service.UserInformation.Interface;
using Xrun.Service.UserInformation.Response;
using Xrun.Service.UserInformation.Request;

namespace Xrun.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationService _userinformationService;
        public UserInformationController(IUserInformationService userInformationService)
        {
            _userinformationService = userInformationService;
        }


        /// <summary>
        /// 存入健保卡資料
        /// </summary>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserInformationRequest userInformationRequest)
        {
            LoginResponse result = await _userinformationService.Login(userInformationRequest);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }


        [HttpPost("GetAllUserInformation")]
        public async Task<IActionResult> GetAllUserInformation()
        {
            var result = await _userinformationService.GetAllUserInformation();
            return Ok(result);
        }

    }
}
