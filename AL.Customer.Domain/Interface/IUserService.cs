using AL.Customer.Effigy.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Interface
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        UserViewModel GetUser(int userId);

        UserViewModel GetUserByUsername(string userName);
        bool RegisterUser(RegisterViewModel registerDtos);
        bool ValidatePassword(LoginDto loginDtos);
    }
}
