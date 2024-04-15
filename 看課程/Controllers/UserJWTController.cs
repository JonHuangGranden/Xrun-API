using Microsoft.AspNetCore.Mvc;
//using 看課程.Models;
using 看課程.Services.Identity;
using 看課程.Service.Identity.Requests;
using Service.Identity.Interface;
using 看課程.Service.Identity.Response;


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
        public async Task<IActionResult> Register([FromBody] RegisterReq userRequest)
        {
            await _identityService.Register(userRequest);
            return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
        }

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReq loginRequest)
        {
            LoginResult result = await _identityService.Login(loginRequest);
            if (!result.Success)
            {
                return Unauthorized(new { Message = result.ErrorMessage });
            }
            return Ok(result); 
        }
    }
}
