using Microsoft.AspNetCore.Mvc;
//using 看課程.Models;
using 看課程.Services.Identity;
using 看課程.Service.Identity.Requests;
using Service.Identity.Interface;
using 看課程.Service.Identity.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity.Data;


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

        //================================================

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterReq userRequest)
        {
            RegisterRes result = await _identityService.Register(userRequest);
            return result.Success ? Ok(result) : Unauthorized(result);
            //return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
        }

        //================================================

        [HttpPut("Login")]
        //[EnableCors("AllowLocalhost5500")]  
        // 确保使用与全局CORS策略名称相匹配的策略
        public async Task<IActionResult> Login([FromBody] LoginReq loginRequest)
        {
            LoginRes result = await _identityService.Login(loginRequest);
            return result.Success ? Ok(result) : Unauthorized(result);
        }
    }
}
