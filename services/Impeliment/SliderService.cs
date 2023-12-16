
using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Http;
using services.Contracts;
using services.tools.Image;
using services.Vm;

namespace services.Impeliment
{
    public class SliderService : ISliderService
    {
        private readonly DataBaseContext _context;
        public SliderService(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult createSlider(IFormFile img)
        {
            var image = string.Empty;
            if (img.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(img.FileName);
                img.AddImageToServer(imageName, PathExtention.SliderOriginServer, null, null, null, null);
                image = imageName;
            }
            else
            {
                return new BaseResult() { IsSuccess = false, Message = "لطفا فایل تصویر انتخاب کنید." };
            }
            Slider slider = new Slider
            {
                ImagePath = image
            };
            _context.Slider.Add(slider);
            _context.SaveChanges();
            return new BaseResult() { IsSuccess = true, Message = "اسلایدر با موفقیت ایجاد شد." };
        }

        public BaseResult deleteSlider(int id)
        {
            var slider = _context.Slider.FirstOrDefault(x => x.Id == id);
            if (slider == null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "اسلاید یافت نشد."
                };
            }
            _context.Slider.Remove(slider);
            if (!string.IsNullOrWhiteSpace(slider.ImagePath))
            {
                if (File.Exists(PathExtention.SliderOriginServer + slider.ImagePath))
                    File.Delete(PathExtention.SliderOriginServer + slider.ImagePath);
            }
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "اسلاید حذف گردید."
            };
        }

        public BaseResult<List<Slider>> getAll()
        {
            return new BaseResult<List<Slider>>
            {
                Data = _context.Slider.ToList(),
            };
        }
    }
}