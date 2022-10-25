using System.Collections.Generic;
using UserService.Entities;

namespace UserService.SV
{
    public interface IUserService
    {
        public IEnumerable<User> GetList();
     //   public User GetById(int id);
        public User Add(User user);
     //   public User Update(User user);
      //  public bool Delete(int Id);
    }
}
