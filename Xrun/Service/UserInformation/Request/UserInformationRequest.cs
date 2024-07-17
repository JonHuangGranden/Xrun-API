using System;
namespace Xrun.Service.UserInformation.Request
{

    public class NHINumberRequest
    {
        public string NHINumber { get; set; }
    
    }

    public class UserInformationRequest
    {
        public string Name { get; set; }
        public string NHINumber { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
    }

    

}
