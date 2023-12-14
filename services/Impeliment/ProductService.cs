
using Core.Data;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using services.Contracts;
using services.tools.Image;
using services.Vm;

namespace services.Impeliment
{
    public class ProductService : IProductService
    {
        private readonly DataBaseContext _context;
        public ProductService(DataBaseContext context)
        {
            _context = context;

        }
        public BaseResult createGallery(int id, List<IFormFile> images)
        {
            List<ProductGallery> productsGalleries = new List<ProductGallery>();
            foreach (var gallery in images)
            {
                if (gallery.IsImage())
                {
                    var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(gallery.FileName);
                    gallery.AddImageToServer(imageName, PathExtention.ProductGalleryOriginServer, null, null, null, null);
                    
                    productsGalleries.Add(new ProductGallery{
                        ImagePath=imageName,
                        ProductId=id
                    });
                }
            }
            _context.ProductGalleries.AddRange(productsGalleries);
            _context.SaveChanges();
            return new BaseResult(){};
        }

        public BaseResult createProduct(CreateProduct product,List<CreateAttribute> createAttributes)
        {
            var img = string.Empty;
            if (product.CoverPath.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(product.CoverPath.FileName);
                product.CoverPath.AddImageToServer(imageName, PathExtention.ProductCoverOriginServer, null, null, null, null);
                img = imageName;
            }
            else
            {
                return new BaseResult() { IsSuccess = false, Message = "لطفا فایل تصویر انتخاب کنید." };
            }
            Product productInit = new Product
            {
                CategoryId = product.CategoryId,
                CoverPath = img,
                LongDescription = product.LongDescription,
                Model = product.Model,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
            };
            _context.Products.Add(productInit);
            _context.SaveChanges();
            if (createAttributes.Any() || createAttributes.Count() > 0)
            {
                List<ProductAttribute> productAttributes = new List<ProductAttribute>();
                foreach (var attr in createAttributes)
                {
                    productAttributes.Add(new ProductAttribute
                    {
                        AttributeName = attr.AttributeName,
                        AttributeValue = attr.AttributeValue,
                        Product = productInit,
                    });
                }
                _context.ProductAttributes.AddRange(productAttributes);
            }
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "محصول با موفقیت ثبت شد."
            };
        }

        public BaseResult deleteGalleryImage(int galleryId)
        {
            throw new NotImplementedException();
        }

        public BaseResult deleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public BaseResult editProduct(int id, CreateProduct product)
        {
            throw new NotImplementedException();
        }

        public BaseResult<List<Product>> getAll(string? searchKey)
        {
            return new BaseResult<List<Product>>{
                Data=_context.Products
                .Include(x=>x.Category)
                .ThenInclude(x=>x.ParentCategory).ToList()
            };
        }
    }
}