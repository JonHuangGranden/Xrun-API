using System.Threading.Tasks;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.DataAccess.GameData.Interface
{
    public interface IGameDataDataAccess
    {
        //Task InsertGameDataAsync<T>(T gameData) where T : class;


        Task<UserAllGameDataList> GetByNHINumberAsync(int nhiNumber);



        Task InsertGameDataAsync(object gameData);
      

        Task InsertUserGameDataAsync(UserAllGameDataList userGameData);


    }
}



//約束的條件： T 必須是 class
//泛型方法 InsertGameDataAsync<T>(T gameData) where T : class 中的<T> 由調用方法時傳入的參數類型決定。
//這意味著當你調用這個方法並傳入一個具體類型的參數時，編譯器會自動推斷出 T 的類型。


//調用過程詳解
//調用 InsertGameDataAsync(beetleData)：

//你傳入一個 BeetleGameData 類型的參數。
//編譯器看到這個參數是 BeetleGameData 類型，因此將 T 推斷為 BeetleGameData。
//方法體內的 T 全部替換為 BeetleGameData。
//調用 InsertGameDataAsync(cardData)：

//你傳入一個 CardGameData 類型的參數。
//編譯器看到這個參數是 CardGameData 類型，因此將 T 推斷為 CardGameData。
//方法體內的 T 全部替換為 CardGameData。