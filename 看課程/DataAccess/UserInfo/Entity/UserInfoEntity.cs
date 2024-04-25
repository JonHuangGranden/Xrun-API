using System;
namespace 看課程.DataAccess.UserInfo.Entity
{
    public class UserInfoToDB
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsBlacklisted { get; set; }  


    }
}

