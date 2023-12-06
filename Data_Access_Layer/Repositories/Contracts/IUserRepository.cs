using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int userId);

        Task<User> GetUserByUserName(string userName);

        Task<IEnumerable<User>> GetAllUsers();
        User Update(User user);

    }
}
