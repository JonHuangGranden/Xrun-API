using System;
namespace Xrun.Repositories.BackpageUserData
{
    public class BackpageUserAllGameDataListEntity
    {
        public string Id { get; set; }
        public string NHINumber { get; set; }
        public List<BeetleGameData> BeetleGameDatas { get; set; }
        public List<CardGameData> CardGameDatas { get; set; } 
        public List<MarbleGameData> MarbleGameDatas { get; set; } 
        public List<FruitGameData> FruitGameDatas { get; set; } 
    }

    public class BeetleGameData
    {
        public string Id { get; set; }
        public DateTime GameTime { get; set; } 
        public string NHINumber { get; set; }
        public int LeftHandSuccessCount { get; set; }
        public int RightHandSuccessCount { get; set; }
        public int BestLeftHandSuccessCount { get; set; }
        public int BestRightHandSuccessCount { get; set; }
    }

    public class CardGameData
    {
        public string Id { get; set; } 
        public DateTime GameTime { get; set; }
        public string NHINumber { get; set; }
        public int LeftHandSuccessCount { get; set; }
        public int RightHandSuccessCount { get; set; }
        public int BestLeftHandSuccessCount { get; set; }
        public int BestRightHandSuccessCount { get; set; }
    }

    public class MarbleGameData
    {
        public string Id { get; set; } 
        public DateTime GameTime { get; set; } 
        public string NHINumber { get; set; }
        public int MaxLeftHandAngle { get; set; }
        public int MaxRightHandAngle { get; set; }
    }

    public class FruitGameData
    {
        public string Id { get; set; } 
        public DateTime GameTime { get; set; }
        public string NHINumber { get; set; }
        public int SuccessCount { get; set; }
        public int TotalSuccessSeconds { get; set; }
    }


}



