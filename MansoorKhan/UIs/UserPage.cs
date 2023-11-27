using MansoorKhan.Models;
using MansoorKhan.Services;

namespace MansoorKhan.UIs;

public class UserPage
{
    User user = new();
    UserService userService = new(); 
    public void Create()
    {
        Console.WriteLine("Ism: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Familiya: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("id: ");
        long id = long.Parse(Console.ReadLine());

        user.FirstName = firstName;
        user.LastName = lastName;
        user.Id = id;

        userService.Create(user);
    }
}
