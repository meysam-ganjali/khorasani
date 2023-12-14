

using System.Security.Principal;
using Core.Models;
using services.Vm;

namespace services.Contracts
{
    public interface ICategoryService
    {
        BaseResult createParent(ParentCategory category);
        BaseResult createChild(Category category);
        BaseResult editeChild(Category category);
        BaseResult editeParent(ParentCategory category);
        BaseResult deleteParent(int id);
        BaseResult deleteChild(int id);
        BaseResult<List<ParentCategory>> getAllParent();
        BaseResult<List<Category>> getAllChild();
        BaseResult<List<Category>> getAllChildByParent(int parentId);

    }
}