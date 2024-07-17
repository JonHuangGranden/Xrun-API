
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] NHINumberRequest NHINumberRequest)
        {
            LoginResponse result = await _userinformationService.Login(NHINumberRequest);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserInformationRequest userInformationRequest)
        {
            RegisterResponse result = await _userinformationService.Register(userInformationRequest);
            return result.IsSuccess ? Ok(result) : NotFound(result);

        }

    }
}
