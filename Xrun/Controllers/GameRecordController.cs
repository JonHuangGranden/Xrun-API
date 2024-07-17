//using Microsoft.AspNetCore.Mvc;
//using Xrun.Service.Identity.Requests;
//using Service.Identity.Interface;
//using Xrun.Service.Identity.Response;
//using System.Diagnostics;


//namespace Xrun.Controllers
//{
//    [Route("record/[controller]")]
//    [ApiController]
//    public class UserJWTController : ControllerBase
//    {
//        private readonly IIdentityService _identityService;
//        public GameRecordController(IIdentityService identityService)
//        {
//            //_identityService = identityService;
//        }
//        [HttpPost("Register")]
//        public async Task<IActionResult> GetRecord([FromBody] RegisterReq registerReq)
//        {
//            //RegisterRes result = await _identityService.Register(registerReq);
//            //return result.Success ? Ok(result) : Unauthorized(result);
//            //return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
//        }
 

//    }
//}
