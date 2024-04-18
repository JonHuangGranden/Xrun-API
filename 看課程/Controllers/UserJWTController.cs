using Microsoft.AspNetCore.Mvc;
using 看課程.Service.Identity.Requests;
using Service.Identity.Interface;
using 看課程.Service.Identity.Response;
using System.Diagnostics;


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
        //=====================================================================================
        //=====================================================================================
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterReq userRequest)
        {
            RegisterRes result = await _identityService.Register(userRequest);
            return result.Success ? Ok(result) : Unauthorized(result);
            //return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
        }
        //=====================================================================================
        //=====================================================================================
        [HttpPut("Login")]
        //[EnableCors("AllowLocalhost5500")]  
        public async Task<IActionResult> Login([FromBody] LoginReq loginRequest)
        {
            LoginRes result = await _identityService.Login(loginRequest);
            return result.Success ? Ok(result) : Unauthorized(result);
        }
        //=====================================================================================
        //=====================================================================================
        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromHeader(Name = "Authorization")] string authorization)
        {
            var token = authorization?.Split(" ").Last();
            
            //移除bearer

            var result = await _identityService.verifyRefreshToken(token);

            return result.Success ? Ok(result) : Unauthorized(result);


            //if (refreshTokenReq == null || string.IsNullOrWhiteSpace(refreshTokenReq))
            //{
            //    return BadRequest("需要提供refresh token。");
            //}

            //LoginRes result = await _identityService.RefreshToken(authorization);
        }
        //==================================
        [HttpPost("useAccess")]
        public async Task<IActionResult> useAccess([FromHeader(Name = "Authorization")] string authorization)
        {
            var token = authorization?.Split(" ").Last();
            var result = await _identityService.verifyAccessToken(token);
            return result.Success ? Ok(result) : Unauthorized(result);
        }

    }
}
