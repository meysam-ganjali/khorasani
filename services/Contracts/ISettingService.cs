
using Core.Models;
using services.Vm;

namespace services.Contracts
{
    public interface ISettingService
    {
        BaseResult createSetting(CreateSetting p);
        BaseResult deleteSetting(int id);
        BaseResult<Setting> getSetting();
    }
}