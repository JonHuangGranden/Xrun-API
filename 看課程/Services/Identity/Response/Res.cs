namespace 看課程.Service.Identity.Response
{

    public class LoginRes
    {
        public string UserName { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    
    }

    public class RefreshTokenRes
    {
        public bool Success { get; set; }
        public string Msg { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }

    public class RegisterRes
    {
        public string UserName { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
    }

   

}

