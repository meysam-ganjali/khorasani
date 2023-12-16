
using Core.Data;
using Core.Models;
using services.Contracts;
using services.tools.Image;
using services.Vm;

namespace services.Impeliment
{
    public class CompetitivedvantagesService : ICompetitivedvantagesService
    {
        private readonly DataBaseContext _context;
        public CompetitivedvantagesService(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult create(CreateCompetitiveAdvantage competitive)
        {
            var img = string.Empty;

            var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(competitive.LogoPath.FileName);
            competitive.LogoPath.AddImageToServer(imageName, PathExtention.CompetitivedvantagesOriginServer, null, null, null, null);
            img = imageName;

            CompetitiveAdvantage competitiveAdvantage = new CompetitiveAdvantage
            {
                Name = competitive.Name,
                LogoPath = img
            };

            _context.CompetitiveAdvantages.Add(competitiveAdvantage);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "مزیت رقابتی با موفقیت ثبت گردید."
            };
        }

        public BaseResult delete(int id)
        {
            var res = _context.CompetitiveAdvantages.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "مزیت رقابتی یافت نشد."
                };
            }

            if (!string.IsNullOrWhiteSpace(res.LogoPath))
            {
                if (File.Exists(PathExtention.CompetitivedvantagesOriginServer + res.LogoPath))
                    File.Delete(PathExtention.CompetitivedvantagesOriginServer + res.LogoPath);
            }
            _context.CompetitiveAdvantages.Remove(res);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "مزیت رقابتی حذف گردید"
            };
        }
        public BaseResult<List<CompetitiveAdvantage>> getAll()
        {
            return new BaseResult<List<CompetitiveAdvantage>>
            {
                Data = _context.CompetitiveAdvantages.ToList()
            };
        }
    }
}