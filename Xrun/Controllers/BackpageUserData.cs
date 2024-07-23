
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.BackpageUserData;
using Xrun.Service.BackpageUserData;
using Xrun.Service.BackpageUserData.Interface;

namespace Xrun.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BackpageUserDataController : ControllerBase
    {
        private readonly IBackpageUserDataService _backpageUserDataService;
        public BackpageUserDataController(IBackpageUserDataService backpageUserDataService)
        {
            _backpageUserDataService = backpageUserDataService;
        }


        /// <summary>
        /// 取得一位用戶遊戲資料
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetUserAllGameData")]
        public async Task<IActionResult> GetUserAllGameData([FromBody] NHINumberRequest nhiNumberRequest)
        {          
            var result = await _backpageUserDataService.GetBackpageUserAllGameDataListAsync(nhiNumberRequest);
            return Ok(result);
        } 


    }
}
