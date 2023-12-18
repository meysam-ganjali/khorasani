
using Core.Data;
using Core.Models;
using services.Contracts;
using services.tools.Image;
using services.Vm;

namespace services.Impeliment
{
    public class CompletedProject : ICompletedProject
    {
        private readonly DataBaseContext _context;
        public CompletedProject(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult createProject(CreateProject p)
        {
            var image = string.Empty;
            if (p.Picture.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(p.Picture.FileName);
                p.Picture.AddImageToServer(imageName, PathExtention.ProjectOriginServer, null, null, null, null);
                image = imageName;
            }
            else
            {
                return new BaseResult() { IsSuccess = false, Message = "لطفا فایل تصویر انتخاب کنید." };
            }
            Company company = new Company()
            {
                CompanuPhone = p.CompanuPhone,
                CompanyAddress = p.CompanyAddress,
                CompanyLogo = image,
                CompanyName = p.CompanyName,
                Description = p.Description,
                Title = p.Title

            };
            _context.Companies.Add(company);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "پروژه با موفقیت اضافه شد."
            };
        }

        public BaseResult deleteProject(int id)
        {
            var p = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "پروژه یافت نشد"
                };
            }
            _context.Companies.Remove(p);
            if (!string.IsNullOrWhiteSpace(p.CompanyLogo))
            {
                if (File.Exists(PathExtention.ProjectOriginServer + p.CompanyLogo))
                    File.Delete(PathExtention.ProjectOriginServer + p.CompanyLogo);
            }
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "پروژه از سیستم حذف گردید."
            };

        }

        public BaseResult<List<Company>> getAll()
        {
           return new BaseResult<List<Company>>{
            Data=_context.Companies.ToList(),
           };
        }

        public BaseResult<Company> getProject(int id)
        {
              var p = _context.Companies.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return new BaseResult<Company>
                {
                    IsSuccess = false,
                    Message = "پروژه یافت نشد"
                };
            }
            return new BaseResult<Company>{
                Data=p,
                IsSuccess=true
            };
        }
    }
}