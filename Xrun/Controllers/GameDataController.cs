
using Microsoft.AspNetCore.Mvc;
using Xrun.Service.GameData;

using Xrun.DataAccess.GameData.Entity;
using Xrun.Service.GameData.Interface;
using Xrun.Service.GameData;
using Xrun.Service.UserInformation.Request;


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


        /// <summary>
        /// 存入抓獨角仙遊戲紀錄
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertBeetleGameData")]
        public async Task<IActionResult> InsertBeetleGameData([FromBody] BeetleGameDataRequest request)
        {
            var beetleGameData = new BeetleGameData
            {
                NHINumber = request.NHINumber,
                LeftHandSuccessCount = request.LeftHandSuccessCount,
                RightHandSuccessCount = request.RightHandSuccessCount,
                BestLeftHandSuccessCount = request.BestLeftHandSuccessCount,
                BestRightHandSuccessCount = request.BestRightHandSuccessCount
            };          
            InsertGameDataResponse result =await _gameDataService.CreateOrUpdateGameDataAsync(beetleGameData);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }


        /// <summary>
        /// 存入鬥牌遊戲紀錄
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertCardGameData")]
        public async Task<IActionResult> InsertCardGameData([FromBody] CardGameDataRequest request)
        {
            var cardGameData = new CardGameData
            {
                NHINumber = request.NHINumber,
                LeftHandSuccessCount = request.LeftHandSuccessCount,
                RightHandSuccessCount = request.RightHandSuccessCount,
                BestLeftHandSuccessCount = request.BestLeftHandSuccessCount,
                BestRightHandSuccessCount = request.BestRightHandSuccessCount
            };          
            InsertGameDataResponse result = await _gameDataService.CreateOrUpdateGameDataAsync(cardGameData);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }


        /// <summary>
        /// 存入打彈珠遊戲紀錄
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertMarbleGameData")]
        public async Task<IActionResult> InsertMarbleGameData([FromBody] MarbleGameDataRequest request)
        {
            var marbleGameData = new MarbleGameData
            {
                NHINumber = request.NHINumber,
                MaxLeftHandAngle = request.MaxLeftHandAngle,
                MaxRightHandAngle = request.MaxRightHandAngle
            };         
            InsertGameDataResponse result = await _gameDataService.CreateOrUpdateGameDataAsync(marbleGameData);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }


        /// <summary>
        /// 存入賣水果遊戲紀錄
        /// </summary>
        /// <returns></returns>
        [HttpPost("InsertFruitGameData")]
        public async Task<IActionResult> InsertFruitGameData([FromBody] FruitGameDataRequest request)
        {
            var fruitGameData = new FruitGameData
            {
                NHINumber = request.NHINumber,              
                SuccessCount = request.SuccessCount,
                TotalSuccessSeconds = request.TotalSuccessSeconds
            };        
            InsertGameDataResponse result =await _gameDataService.CreateOrUpdateGameDataAsync(fruitGameData);         
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }


    }
}
