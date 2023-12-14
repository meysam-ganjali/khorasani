
using Core.Models;
using services.Vm;

namespace services.Contracts
{
    public interface IRoleService
    {
        BaseResult<List<Role>> getAllRole();
        BaseResult createRole(Role role);
    }
}