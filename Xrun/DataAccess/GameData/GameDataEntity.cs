using System;
namespace Xrun.DataAccess.GameData.Entity
{
    public class UserAllGameDataList
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int NHINumber { get; set; }
        public List<BeetleGameData> BeetleGameDatas { get; set; } = new List<BeetleGameData>();
        public List<CardGameData> CardGameDatas { get; set; } = new List<CardGameData>();
        public List<MarbleGameData> MarbleGameDatas { get; set; } = new List<MarbleGameData>();
        public List<FruitGameData> FruitGameDatas { get; set; } = new List<FruitGameData>();
    }


    public class BeetleGameData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime GameTime { get; set; } = DateTime.UtcNow.AddHours(8);
        public int NHINumber { get; set; }
        public int LeftHandSuccessCount { get; set; }
        public int RightHandSuccessCount { get; set; }
        public int BestLeftHandSuccessCount { get; set; }
        public int BestRightHandSuccessCount { get; set; }
    }

    public class CardGameData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime GameTime { get; set; } = DateTime.UtcNow.AddHours(8);
        public int NHINumber { get; set; }
        public int LeftHandSuccessCount { get; set; }
        public int RightHandSuccessCount { get; set; }
        public int BestLeftHandSuccessCount { get; set; }
        public int BestRightHandSuccessCount { get; set; }
    }

    public class MarbleGameData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime GameTime { get; set; } = DateTime.UtcNow.AddHours(8);
        public int NHINumber { get; set; }
        public int MaxLeftHandAngle { get; set; }
        public int MaxRightHandAngle { get; set; }
    }

    public class FruitGameData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime GameTime { get; set; } = DateTime.UtcNow.AddHours(8);
        public int NHINumber { get; set; }
        public int SuccessCount { get; set; }
        public int TotalSuccessSeconds { get; set; }
    }



}


