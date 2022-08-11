using AL.Customer.Data.DbModels;
using AL.Customer.Data.Interface;
using System.Collections.Generic;
using System.Linq;

namespace AL.Customer.Data.Services
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FirstMarketContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public IEnumerable<User> GetUserByGender(string gender)
        {
            return db.Users.Where(a => a.Gender == gender).ToList();
        }

        public User GetUserById(int Id)
        {
            return db.Users.Where(a => a.Id == Id).FirstOrDefault();
        }

        public User GetUserByName(string userName)
        {
            return db.Users.Where(a => a.UserName == userName).FirstOrDefault();
        }

        public bool SaveUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
    }
}
