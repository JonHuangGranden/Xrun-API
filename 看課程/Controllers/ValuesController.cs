using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace 看課程.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        // 只有管理员可以访问的方法
        [HttpGet]
        [Authorize(Policy = "ReqRole")]
        public IActionResult Get()
        {
            return Ok("只有管理员可以看到这个信息");
        }

    }
}
