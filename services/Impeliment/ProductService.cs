
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

        public BaseResult createAttribute(CreateAttribute attr, int pId)
        {
            ProductAttribute ProductAttr = new ProductAttribute{
                AttributeName=attr.AttributeName,
                AttributeValue=attr.AttributeValue,
                ProductId=pId
            };
            _context.ProductAttributes.Add(ProductAttr);
            _context.SaveChanges();
            return new BaseResult{
                IsSuccess=true,
                Message="مشخصه اضافه گردید."
            };
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

                    productsGalleries.Add(new ProductGallery
                    {
                        ImagePath = imageName,
                        ProductId = id
                    });
                }
            }
            _context.ProductGalleries.AddRange(productsGalleries);
            _context.SaveChanges();
            return new BaseResult()
            {
                IsSuccess = true,
                Message = "گالری با موفقیت ثبت گردید."
            };
        }

        public BaseResult createProduct(CreateProduct product, List<CreateAttribute> createAttributes)
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

        public BaseResult deleteAttribute(int attrId)
        {
            var attr = _context.ProductAttributes.FirstOrDefault(x=>x.Id == attrId);
            if(attr == null){
                return  new BaseResult{
                    IsSuccess=false,
                    Message="مشخصه یافت نشد."
                };
            }
            _context.ProductAttributes.Remove(attr);
            _context.SaveChanges();
 return  new BaseResult{
                    IsSuccess=true,
                    Message="مشخصه حذف شد."
                };
        }

        public BaseResult deleteGalleryImage(int galleryId)
        {
            ProductGallery? gallery = _context.ProductGalleries.FirstOrDefault(x => x.Id == galleryId);
            if (gallery == null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "تصویر یافت نشد"
                };
            }
            _context.ProductGalleries.Remove(gallery);
            if (!string.IsNullOrWhiteSpace(gallery.ImagePath))
            {
                if (File.Exists(PathExtention.ProductGalleryOriginServer + gallery.ImagePath))
                    File.Delete(PathExtention.ProductGalleryOriginServer + gallery.ImagePath);
            }
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "تصویر از لیسست گالری محصول حذف گردید."
            };
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
            var products = _context.Products
            .Include(x => x.ProductGalleries)
            .Include(x => x.ProductAttributes)
             .Include(x => x.Category)
             .ThenInclude(x => x.ParentCategory)
             .AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                products = products.Where(x => x.Name.Contains(searchKey));
            }
            return new BaseResult<List<Product>>
            {
                Data = products.ToList()
               .ToList()
            };
        }

        public BaseResult<List<ProductGallery>> getAllGallery(int productId)
        {
            var res = _context.ProductGalleries
            .Include(x => x.Product)
            .Where(x => x.ProductId == productId);
            if (res == null)
            {
                return new BaseResult<List<ProductGallery>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "گالری برای محصول یافت نشد"
                };
            }
            return new BaseResult<List<ProductGallery>>()
            {
                Data = res.ToList(),
                IsSuccess = true,

            };
        }

        public BaseResult<List<ProductAttribute>> getProductAttribute(int productId)
        {
            var res = _context.ProductAttributes.Include(x => x.Product)
            .Where(x => x.ProductId == productId).ToList();
            return new BaseResult<List<ProductAttribute>>
            {
                Data = res,
                IsSuccess = true
            };
        }
    }
}