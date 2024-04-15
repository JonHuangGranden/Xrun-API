using Microsoft.AspNetCore.Mvc;
//using 看課程.Models;
using 看課程.Services.Identity;
using 看課程.Service.Identity.Requests;
using Service.Identity.Interface;


namespace 看課程.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserJWTController : ControllerBase
    {
        private readonly IIdentityService _identityService; 

        public UserJWTController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequestToRegister userRequest)
        {
            await _identityService.Register(userRequest);
            return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReq loginRequest)
        {


            try
            {
                var isValid = await _identityService.Login(loginRequest);
                if (isValid == null)
                {
                    return Unauthorized(new { Message = "登入失敗" });
                }
                return Ok(new
                {
                    Token = isValid,
                    Message = "登入成功"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "伺服器錯誤", Error = ex.Message });
            }
        }
    }
}
