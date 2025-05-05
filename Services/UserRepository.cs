using Rentify.Data;
using Rentify.Models;

namespace Rentify.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return db.users.ToList();
        }

        public Users GetUserById(int id)
        {
            return db.users.Where(x => x.UserId == id).SingleOrDefault();
        }

        public int AddUser(Users user)
        {
            int res = 0;
            db.users.Add(user);
            res = db.SaveChanges();
            return res;
        }

        public Users Login(string email, string password)
        {
            return db.users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }


        public int UpdateUser(Users user)
        {
            int result = 0;
            var res = db.users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (res != null)
            {
                res.UserId = user.UserId;
                res.FirstName = user.FirstName;
                res.LastName = user.LastName;
                res.PhoneNumber = user.PhoneNumber;
                res.Address = user.Address;
                res.Email = user.Email;
                res.Password = user.Password;
                res.RoleId = user.RoleId;

                result = db.SaveChanges();

            }
            return result;
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            var res = db.users.Where(x => x.UserId == id).FirstOrDefault();
            if (res != null)
            {
                db.users.Remove(res);
                result = db.SaveChanges();
            }
            return result;
        }



    }
}


