using AL.Customer.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Data.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> GetAllUsers();

        User GetUserById(int Id);

        User GetUserByName(string userName);

        IEnumerable<User> GetUserByGender(string gender);

        bool SaveUser(User user);
    }
}
