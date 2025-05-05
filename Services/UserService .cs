using Rentify.Models;
using Rentify.Repositories;

namespace Rentify.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }

        public int AddUser(Users user)
        {
            return repo.AddUser(user);
        }

        public int DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return repo.GetAllUsers();
        }

        public Users GetUserById(int id)
        {
            return repo.GetUserById(id);
        }

        public Users Login(string email, string password)
        {
            return repo.Login(email, password);
        }

        public int UpdateUser(Users user)
        {
            return repo.UpdateUser(user);
        }
    }
}
