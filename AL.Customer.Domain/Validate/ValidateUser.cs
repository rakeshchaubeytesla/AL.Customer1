using AL.Customer.Data.DbModels;
using AL.Customer.Effigy.DTOModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Validate
{
    public static class ValidateUser
    {
        public static bool VerifyPassword(LoginDto loginDtos, User user)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDtos.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) 
                    return false;
            }
            return true;
        }
    }
}
