using Models;

namespace Data.Interfaces
{
    public interface IUserData : IRepo<User>
    {
        User ValidatieUser(string email, string password);
    }
}
