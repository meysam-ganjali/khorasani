
using Core.Data;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using services.Contracts;
using services.Vm;

namespace services.Impeliment
{
    public class CategoryServie : ICategoryService
    {
        private readonly DataBaseContext _context;
        public CategoryServie(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult createChild(Category category)
        {
            bool isExist = _context.Categories.Any(x => x.Name.Equals(category.Name));
            if (isExist)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "دسته بندی تکراری می باشد."
                };
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت ثبت شد."
            };
        }

        public BaseResult createParent(ParentCategory category)
        {
             bool isExist = _context.ParentCategories.Any(x=>x.Name.Equals(category.Name));
            if(isExist){
                return new BaseResult{
                    IsSuccess=false,
                    Message="دسته بندی تکراری می باشد."
                };
            }
            _context.ParentCategories.Add(category);
            _context.SaveChanges();
              return new BaseResult{
                    IsSuccess=true,
                    Message="دسته بندی با موفقیت ثبت شد."
                };
        }

        public BaseResult deleteChild(int id)
        {
           Category? category=_context.Categories.FirstOrDefault(x=>x.Id == id);
            if(category == null){
                return new BaseResult{
                    IsSuccess=false,
                    Message="دسته بندی یافت نشد."
                };
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
             return new BaseResult{
                    IsSuccess=true,
                    Message=$"دسته بندی {category.Name} از سیستم حذف گردید."
                };
        }

        public BaseResult deleteParent(int id)
        {
            ParentCategory? category = _context.ParentCategories
            .Include(x=>x.Categories)
            .FirstOrDefault(x=>x.Id == id);

            if(category == null){
                return new BaseResult{
                    IsSuccess=false,
                    Message="دسته بندی یافت نشد."
                };
            }
            if(category.Categories.Any()){
                foreach (var child in category.Categories)
                {
                    _context.Categories.Remove(child);
                }
            }
            _context.ParentCategories.Remove(category);
            _context.SaveChanges();
             return new BaseResult{
                    IsSuccess=true,
                    Message=$"دسته بندی {category.Name} از سیستم حذف گردید."
                };
        }

        public BaseResult editeChild(Category category)
        {
            Category? childCategory=_context.Categories.FirstOrDefault(x=>x.Id == category.Id);
            if(category == null){
                return new BaseResult{
                    IsSuccess=false,
                    Message="دسته بندی یافت نشد."
                };
            }
            childCategory.Name = category.Name;
            childCategory.ParentId = category.ParentId;
            _context.SaveChanges();
              return new BaseResult{
                    IsSuccess=true,
                    Message="دسته بندی با موفقیت بروز شد"
                };
        }

        public BaseResult editeParent(ParentCategory category)
        {
            ParentCategory? childCategory=_context.ParentCategories.FirstOrDefault(x=>x.Id == category.Id);
            if(category == null){
                return new BaseResult{
                    IsSuccess=false,
                    Message="دسته بندی یافت نشد."
                };
            }
            childCategory.Name = category.Name;
            _context.SaveChanges();
              return new BaseResult{
                    IsSuccess=true,
                    Message="دسته بندی با موفقیت بروز شد"
                };
        }

        public BaseResult<List<Category>> getAllChild()
        {
            return new BaseResult<List<Category>>{
                Data=_context.Categories.ToList()
            };
        }

        public BaseResult<List<Category>> getAllChildByParent(int parentId)
        {
           return new BaseResult<List<Category>>{
                Data=_context.Categories.Where(x=>x.ParentId == parentId).ToList()
            };
        }

        public BaseResult<List<ParentCategory>> getAllParent()
        {
             return new BaseResult<List<ParentCategory>>{
                Data=_context.ParentCategories.Include(x=>x.Categories).ToList()
            };
        }
    }
}