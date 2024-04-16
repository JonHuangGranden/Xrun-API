using System;
namespace 看課程.Service.Identity.Response
{


    public class LoginRes
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
    }

    public class RegisterRes
    {
        public string UserName { get; set; }
        public bool Success { get; set; }
        public string Msg { get; set; }
    }



}

