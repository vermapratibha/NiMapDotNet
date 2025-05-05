using Rentify.Models;

namespace Rentify.Repositories
{
    public interface IUserRepository
    {

        IEnumerable<Users> GetAllUsers();

        public Users GetUserById(int id);

        public int AddUser(Users user);

        public Users Login(string email, string password);

        public int UpdateUser(Users user);

        public int DeleteUser(int id);

    }
}
