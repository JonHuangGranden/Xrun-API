using Microsoft.AspNetCore.Mvc;
using 看課程.Models;
using 看課程.Services.DataService.Interface;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IDataService _dataService;

    public UsersController(IDataService dataService)
    //這是一個構造函數
    {
        _dataService = dataService;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
        //Task和Task<TResult> 是.NET中用于异步编程的核心类型
    {
        await _dataService.CreateAsync(userRequest);
        return CreatedAtAction(nameof(Register), new { id = userRequest.Id }, userRequest);
        //CreatedAtAction是創建一個HTTP响应（状态码201 Created）

    }


    //==========登入========

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        //这是一个异步的Action方法，接收一个从请求体中绑定的LoginRequest对象作为参数。
    {
        var isValid = await _dataService.ValidateCredentialsAsync(loginRequest);
        //调用_dataService.ValidateCredentialsAsync(loginRequest)：
        ////这个调用请求DataService中的ValidateCredentialsAsync方法来异步验证用户提供的登录凭据是否有效。

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