using Microsoft.AspNetCore.Mvc;
using SimplePostApi.Models;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DataService _dataService;
    public UsersController(DataService dataService)
    //這是一個構造函數
    {
        _dataService = dataService;
    }
   
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        await _dataService.CreateAsync(user);
        return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
    }
}
//namespace SimplePostApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class SimpleController : ControllerBase
//    {
//        [HttpPost]
//        public IActionResult PostMessage([FromBody] TestDt data)
//            //通过[FromBody] 特性将POST请求的正文自动绑定到TestDt类型的参数test上
//        {

//            string responseMessage = $"TestDtMember的值是: {data.TestDtMember}, test的值是: {data.test}";
//            // 将拼接好的字符串作为响应返回
//            return Ok(responseMessage);
//            //return Ok(data);
//            //return Ok("成功!");

//        }
//    }
//}
