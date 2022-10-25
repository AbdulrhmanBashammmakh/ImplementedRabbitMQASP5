using System.Collections.Generic;
using System.Linq;
using UserService.Data;
using UserService.Entities;

namespace UserService.SV
{
    public class UserServices : IUserService
    {
        private readonly UserServiceContext _dbContext;
        public UserServices(UserServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            var result = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public IEnumerable<User> GetList()
        {
            return _dbContext.Users.ToList();
        }
    
    }
}

   

