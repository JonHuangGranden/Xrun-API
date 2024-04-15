using 看課程.Models;
using 看課程.Services.DataService.Interface;

namespace 看課程.Services.DataService
{
    public class MySQLService : IDataService
    {
        public async Task CreateAsync(UserRequest user)
        {
            Console.WriteLine("[My SQL Create]");
        }

        public async Task<bool> ValidateCredentialsAsync(LoginRequest loginRequest)
        {
            Console.WriteLine("[My SQL Validate]");
            return true;
        }
    }
}
