//using Microsoft.AspNetCore.Mvc;
//using Xrun.Service.Identity.Requests;
//using Service.Identity.Interface;
//using Xrun.Service.Identity.Response;
//using System.Diagnostics;


//namespace Xrun.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class AdminAccountController : ControllerBase
//    {
//        private readonly IIdentityService _identityService;
//        public AdminAccountController(IIdentityService identityService)
//        {
//            _identityService = identityService;
//        }


//        [HttpPost("Register")]
//        public async Task<IActionResult> Register([FromBody] RegisterReq registerReq)
//        {
//            RegisterRes result = await _identityService.Register(registerReq);
//            return result.Success ? Ok(result) : Unauthorized(result);
//        }


//        [HttpPost("Login")]
//        public async Task<IActionResult> Login([FromBody] LoginReq loginRequest)
//        {
//            LoginRes result = await _identityService.Login(loginRequest);
//            return result.Success ? Ok(result) : Unauthorized(result);
//        }


//        [HttpPost("Refresh")]
//        public async Task<IActionResult> Refresh([FromHeader(Name = "Authorization")] string authorization)
//        {
//            var token = authorization?.Split(" ").Last();

//            var result = await _identityService.verifyRefreshToken(token);

//            return result.Success ? Ok(result) : Unauthorized(result);
//        }


//        [HttpPost("UseAccess")]
//        public async Task<IActionResult> UseAccess([FromHeader(Name = "Authorization")] string authorization)
//        {
//            var token = authorization?.Split(" ").Last();
//            var result = await _identityService.verifyAccessToken(token);
//            return result.Success ? Ok(result) : Unauthorized(result);
//        }

//    }
//}
