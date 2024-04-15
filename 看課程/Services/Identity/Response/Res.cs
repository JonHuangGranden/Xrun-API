using System;
namespace 看課程.Service.Identity.Response
{


    public class LoginResult
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }



}

