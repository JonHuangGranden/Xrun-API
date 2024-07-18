
using Microsoft.AspNetCore.Mvc;
using Xrun.Service.GameData;

using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.GameData.Interface;
using Xrun.Service.UserInfo.Requests;


namespace Xrun.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameDataController : ControllerBase
    {
        private readonly IGameDataService _gameDataService;
        public GameDataController(IGameDataService gameDataService)
        {
            _gameDataService = gameDataService;
        }



        [HttpPost("InsertBeetleGameData")]
        public async Task<IActionResult> CreateOrUpdateBeetleGameData([FromBody] BeetleGameDataRequest request)
        {
            var beetleGameData = new BeetleGameData
            {
                NHINumber = request.NHINumber,
                LeftHandSuccessCount = request.LeftHandSuccessCount,
                RightHandSuccessCount = request.RightHandSuccessCount,
                BestLeftHandSuccessCount = request.BestLeftHandSuccessCount,
                BestRightHandSuccessCount = request.BestRightHandSuccessCount
            };
            await _gameDataService.CreateOrUpdateGameDataAsync(beetleGameData);
            return Ok();

            //Res result = await _gameDataService.CreateOrUpdateGameDataAsync(beetleGameData);
            //return result.Success ? Ok(result) : NotFound(result);


        }


    }
}
