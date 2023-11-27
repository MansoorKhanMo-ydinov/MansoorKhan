using MansoorKhan.Constants;
using MansoorKhan.Interfaces;
using MansoorKhan.Models;
using Newtonsoft.Json;

namespace MansoorKhan.Services;

public class UserService : IUserService
{
    private string FilePath = UserPath.USER_DB_PATH;

    public UserService()
    {
        string source = File.ReadAllText(FilePath);
        if (string.IsNullOrEmpty(source))
            File.WriteAllText(FilePath, "[]");
    }

    public User Create(User user)
    {
        string source = File.ReadAllText(FilePath);
        List<User> users = JsonConvert.DeserializeObject<List<User>>(source);


        User existUser = users.FirstOrDefault(u => u.FirstName.Equals(user.FirstName));
        if (existUser is not null)
            return null;
        users.Add(user);

        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(FilePath, json);

        return user;


    }

    public User Update(User user)
    {
        List<User> users = GetAll();
        User existUser = users.FirstOrDefault(u => u.LastName.Equals(user.LastName));

        if (existUser is not null)
            return null;

        existUser.FirstName = user.FirstName;
        existUser.LastName = user.LastName;
        existUser.Id = user.Id;

        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(FilePath, json);

        return user;
    }

    public bool Delete(long id)
    {
        List<User> users = GetAll();
        User existUser = users.FirstOrDefault(u => u.Id.Equals(id));

        if (existUser is not null)
            users.Remove(existUser);

        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(FilePath, json);

        return true;
    }

    public User GetById(long id)
        =>GetAll().FirstOrDefault(u => u.Id.Equals(id));

    public List<User> GetAll()
    {
        string source = File.ReadAllText(FilePath);
        if (string.IsNullOrEmpty(source))
            File.WriteAllText(FilePath,"[]");

        return JsonConvert.DeserializeObject<List<User>>(source);
    }
}
