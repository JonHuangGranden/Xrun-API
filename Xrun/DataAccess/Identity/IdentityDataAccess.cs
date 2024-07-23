using Xrun.Repositories.Identity.Interface;
using Xrun.DataAccess.Identity.Entity;
using Xrun.DataAccess.Identity.Interface;

namespace Xrun.DataAccess.Identity
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


        public async Task<UserAccountEntity> GetUserByEmailAsync(string email)
        {
            return await _userToDbRepository.GetUserByEmailAsync(email);
        }
        public async Task<UserAccountEntity> FindUserByIdAsync(string userId)
        {
            return await _userToDbRepository.GetUserByIdAsync(userId);
        }

        public async Task InsertUserAsync(UserAccountEntity user)
        {
            await _userToDbRepository.InsertUserAsync(user);
        }


        public async Task<bool> UpdateUserJtiAsync(string userId, string newJti)
        {
            return await _userToDbRepository.UpdateUserJtiAsync(userId, newJti);
        }


    }
}
