
using Core.Models;
using Microsoft.AspNetCore.Http;
using services.Vm;

namespace services.Contracts
{
    public interface IProductService
    {
        BaseResult createProduct(CreateProduct product,List<CreateAttribute> createAttributes);
        BaseResult createGallery(int id, List<IFormFile> images);

        BaseResult deleteProduct(int id);
        BaseResult deleteGalleryImage(int galleryId);

        BaseResult editProduct(int id, CreateProduct product);

        BaseResult<List<Product>> getAll(string? searchKey);
        BaseResult<List<ProductGallery>> getAllGallery(int productId);
        BaseResult<List<ProductAttribute>> getProductAttribute(int productId);

        BaseResult createAttribute(CreateAttribute attr,int pId);
        BaseResult deleteAttribute(int attrId);

    }
}