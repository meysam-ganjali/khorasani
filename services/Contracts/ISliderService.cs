
using Core.Models;
using Microsoft.AspNetCore.Http;
using services.Vm;

namespace services.Contracts
{
    public interface ISliderService
    {
        BaseResult createSlider(IFormFile img);
        BaseResult deleteSlider(int id);
        BaseResult<List<Slider>> getAll();
    }
}