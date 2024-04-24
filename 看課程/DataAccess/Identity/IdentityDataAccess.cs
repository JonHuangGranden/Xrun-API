using 看課程.Repositories.Interfaces;
using 看課程.DataAccess.Identity.Entity;
using 看課程.DataAccess.Identity.Interface;


namespace 看課程.DataAccess.Identity
{
    public class IdentityDataAccess : IIdentityDataAccess
    {
        //　　　↓↓↓↓注入repositoy
        private readonly IUserToDbRepository _userToDbRepository;
        public IdentityDataAccess(IUserToDbRepository userToDbRepository)
        {
            _userToDbRepository = userToDbRepository;
        }
        //　　　↑↑↑↑注入repositoy



        public async Task<UserDataToDB> GetUserByEmailAsync(string email)
        {
            return await _userToDbRepository.GetUserByEmailAsync(email);
        }
        public async Task<UserDataToDB> FindUserByIdAsync(string userId)
        {
            return await _userToDbRepository.FindUserByIdAsync(userId);
        }


        public async Task InsertUserAsync(UserDataToDB user)
        {
            await _userToDbRepository.InsertUserAsync(user);
        }


        public async Task<bool> UpdateUserJtiAsync(string userId, string newJti)
        {
            return await _userToDbRepository.UpdateUserJtiAsync(userId, newJti);
        }


    }
}
