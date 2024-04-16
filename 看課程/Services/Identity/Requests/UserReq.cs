using System;
namespace 看課程.Service.Identity.Requests
{
    public class RegisterReq
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserDataToDB
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordToHash { get; set; }
        public string Salt { get; set; }
    }
    public class LoginReq
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}

