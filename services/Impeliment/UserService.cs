
using Core.Data;
using Core.Models;
using services.Contracts;
using services.Vm;

namespace services.Impeliment
{
    public class UserService : IUserService
    {
        private readonly DataBaseContext _context;
        public UserService(DataBaseContext context)
        {
            _context = context;
        }
        public BaseResult createUser(User user)
        {
            bool isExist = _context.Users.Any(x => x.CellPhone.Equals(user.CellPhone));
            if (isExist)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "شماره تلفن مورد نظر تکراری است."
                };
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "کاربر جدید با موفقیت ثبت شد"
            };
        }

        public BaseResult deleteUser(int id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new BaseResult
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد."
                };
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return new BaseResult
            {
                IsSuccess = true,
                Message = "کاربر حذف گردید"
            };
        }

        public BaseResult<List<User>> getAllUser()
        {
            return new BaseResult<List<User>>
            {
                Data = _context.Users.ToList(),
                IsSuccess = true
            };
        }

        public BaseResult<User?> getUser(int id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return new BaseResult<User>
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد.",
                    Data = null
                };
            }
            return new BaseResult<User>
            {
                IsSuccess = true,
                Data = user
            };
        }
    }
}