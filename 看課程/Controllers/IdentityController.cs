using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using 看課程.Models;
using 看課程.Services.DataService.Interface;

namespace 看課程.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IDataService _dataService;

        public IdentityController(IDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
        {
            await _dataService.CreateAsync(userRequest);
            return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var isValid = await _dataService.ValidateCredentialsAsync(loginRequest);

            if (isValid)
            {
                return Ok("帳密驗證成功");
            }
            else
            {
                return Unauthorized("帳密錯誤或無此帳號");
            }
        }
    }
}
