
using Core.Models;
using services.Vm;

namespace services.Contracts
{
    public interface ICompetitivedvantagesService
    {
        BaseResult create(CreateCompetitiveAdvantage competitive);
        BaseResult delete(int id);
        BaseResult<List<CompetitiveAdvantage>> getAll();
    }
}