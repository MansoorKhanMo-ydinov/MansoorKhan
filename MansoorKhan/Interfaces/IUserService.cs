using MansoorKhan.Models;

namespace MansoorKhan.Interfaces;

public interface IUserService
{
    User Create(User user);
    User Update(User user);
    bool Delete(long id);
    User GetById(long id);
    List<User> GetAll();
}
