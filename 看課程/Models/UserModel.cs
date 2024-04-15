namespace 看課程.Models
{
    public class UserRequest
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string PasswordToHash { get; set; }
        public string Salt { get; set; }
    }



    public class LoginRequest
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}