using Rentify.Models;

namespace Rentify.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetAllUsers();

        public Users GetUserById(int id);

        public int AddUser(Users user);

        public Users Login(string email, string password);

        public int UpdateUser(Users user);

        public int DeleteUser(int id);
    }
}
