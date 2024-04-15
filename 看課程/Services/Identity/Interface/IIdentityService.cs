using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using 看課程.Service.Identity.Requests;

namespace Service.Identity.Interface
{
    public interface IIdentityService
    {
      
        Task Register(UserRequestToRegister registerRequest);
        
        Task<object> Login(LoginReq loginRequest);
        


    }
}
