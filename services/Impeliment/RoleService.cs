
using Core.Data;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using services.Contracts;
using services.Vm;

namespace services.Impeliment
{
    public class RoleService : IRoleService
    {
        private readonly DataBaseContext _context;
        public RoleService(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult createRole(Role role)
        {
          try
          {
              Role? roleInDatabase =  _context.Roles.FirstOrDefault(x => x.RoleName == role.RoleName);
            if (roleInDatabase != null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "نقش وارد شده تکراری می باشد"
                };
            }
             _context.Roles.Add(role);
             _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "نقش با موفقیت به سیستم اضافه گدید"
            };
          }
          catch (System.Exception e)
          {
            
            return new BaseResult
            {
                IsSuccess = true,
                Message = e.Message
            };
          }
        }

        public BaseResult<List<Role>> getAllRole()
        {
            List<Role> roles =  _context.Roles.ToList();
            return new BaseResult<List<Role>>
            {
                IsSuccess = true,
                Data = roles
            };
        }
    }
}