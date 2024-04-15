using 看課程.Models;
namespace 看課程.Services.DataService.Interface
{
    public interface IDataService
    {
        public Task CreateAsync(UserRequest user);
        public Task<bool> ValidateCredentialsAsync(LoginRequest loginRequest);
    }
    //在C#中，接口（interface）定义的成员默认是public的，
    ////并且不能指定任何其他访问修饰符。因此，在接口定义中明确写出public是多余的
}
