using System;
namespace Xrun.Service.GameData
{    
        public class BeetleGameDataRequest
        {
            public int NHINumber { get; set; }
            public int LeftHandSuccessCount { get; set; }
            public int RightHandSuccessCount { get; set; }
            public int BestLeftHandSuccessCount { get; set; }
            public int BestRightHandSuccessCount { get; set; }
        }

        public class CardGameDataRequest
        {
            public int NHINumber { get; set; }
            public int LeftHandSuccessCount { get; set; }
            public int RightHandSuccessCount { get; set; }
            public int BestLeftHandSuccessCount { get; set; }
            public int BestRightHandSuccessCount { get; set; }
        }

        public class MarbleGameDataRequest
        {
            public int NHINumber { get; set; }
            public int MaxLeftHandAngle { get; set; }
            public int MaxRightHandAngle { get; set; }
        }

        public class FruitGameDataRequest
        {
            public int NHINumber { get; set; }
            public int SuccessCount { get; set; }
            public int TotalSuccessSeconds { get; set; }
        }
    
}
