
using Core.Models;
using services.Vm;

namespace services.Contracts
{
    public interface ICompletedProject
    {
        BaseResult createProject(CreateProject p);
        BaseResult<List<Company>> getAll();
        BaseResult deleteProject(int id);
        BaseResult<Company> getProject(int id);
        
    }
}