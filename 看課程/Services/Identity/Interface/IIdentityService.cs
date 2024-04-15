using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using 看課程.Service.Identity.Requests;
using 看課程.Service.Identity.Response;

namespace Service.Identity.Interface
{
    public interface IIdentityService
    {
      
        Task Register(RegisterReq registerRequest);
        
        Task<LoginResult> Login(LoginReq loginRequest);
        


    }
}
