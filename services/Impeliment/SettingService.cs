
using Core.Data;
using Core.Models;
using services.Contracts;
using services.tools.Image;
using services.Vm;

namespace services.Impeliment
{
    public class SettingService : ISettingService
    {
        private readonly DataBaseContext _context;
        public SettingService(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult createSetting(CreateSetting p)
        {
            var image = string.Empty;
            if (p.LogoPath.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(p.LogoPath.FileName);
                p.LogoPath.AddImageToServer(imageName, PathExtention.SettingOriginServer, null, null, null, null);
                image = imageName;
            }
            else
            {
                return new BaseResult() { IsSuccess = false, Message = "لطفا فایل تصویر انتخاب کنید." };
            }
            Setting sett = new Setting
            {
                Address = p.Address,
                Description = p.Description,
                LogoPath = image,
                Phone1 = p.Phone1,
                Phone2 = p.Phone2,
                Slogan = p.Slogan
            };
            _context.Setting.Add(sett);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد."
            };
        }

        public BaseResult deleteSetting(int id)
        {
            Setting? setting = _context.Setting.FirstOrDefault(x => x.Id == id);
            if (setting == null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "مورد یافت نشد."
                };
            }
            _context.Setting.Remove(setting);
            if (!string.IsNullOrWhiteSpace(setting.LogoPath))
            {
                if (File.Exists(PathExtention.SettingOriginServer + setting.LogoPath))
                    File.Delete(PathExtention.SettingOriginServer + setting.LogoPath);
            }
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد."
            };
        }

        public BaseResult<Setting> getSetting()
        {
            Setting? setting = _context.Setting.FirstOrDefault();
            if (setting == null)
            {
                return new BaseResult<Setting>
                {
                    IsSuccess = false,
                    Message = "مورد یافت نشد."
                };
            }
            return new BaseResult<Setting>
            {
                Data = setting
            };
        }
    }
}