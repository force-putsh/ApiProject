namespace ApiProject.Models
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDemo>> GetAllUsers();
        Task<UserDemo> GetUserById(int id);
        Task<UserDemo> UpdateUser(UserDemo user);
        Task DeleteUser(int id);
        Task<UserDemo> AddUser(UserDemo user);
    }
}
