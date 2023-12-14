
using Core.Models;
using services.Vm;

namespace services.Contracts
{
    public interface IUserService
    {
        BaseResult createUser(User user);
        BaseResult deleteUser(int id);
        BaseResult<List<User>> getAllUser();
        BaseResult<User?> getUser(int id);
    }
}