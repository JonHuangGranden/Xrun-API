using System.Threading.Tasks;
using Xrun.DataAccess.GameData.Entity;

namespace Xrun.DataAccess.GameData.Interface
{
    public interface IGameDataDataAccess
    {
        //Task<List<UserAllGameDataList>> GetAllUserGameDataAsync();

        Task<UserAllGameDataList> GetByNHINumberAsync(string nhiNumber);

        Task InsertGameDataAsync(object gameData);
      
        Task InsertUserGameDataListAsync(UserAllGameDataList userGameData);

    }
}

