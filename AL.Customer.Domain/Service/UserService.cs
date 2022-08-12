using AL.Customer.Data.DbModels;
using AL.Customer.Data.Interface;
using AL.Customer.Domain.Interface;
using AL.Customer.Domain.Validate;
using AL.Customer.Effigy.DTOModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Service
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Defines the User Repository.
        /// </summary>
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper _mapper)
        {
            this.userRepository = _userRepository;
            this.mapper = _mapper;
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = this.userRepository.GetAllUsers();
            return mapper.Map<List<UserViewModel>>(users);
        }

        public UserViewModel GetUser(int userId)
        {
            var user = userRepository.GetUserById(userId);
            return mapper.Map<UserViewModel>(user);
        }

        public UserViewModel GetUserByUsername(string userName)
        {
            var user = userRepository.GetUserByName(userName);
            return mapper.Map<UserViewModel>(user);
        }

        public bool ValidatePassword(LoginDto loginDtos)
        {
            var user = userRepository.GetUserByName(loginDtos.UserName);
            return ValidateUser.VerifyPassword(loginDtos, user);
        }

        public bool RegisterUser(RegisterViewModel registerDtos)
        {
            using var hmac = new HMACSHA512();
            var user = new User()
            {
                UserName = registerDtos.UserName.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDtos.Password)),
                PasswordSalt = hmac.Key,
                DateOfBirth =  registerDtos.DateOfBirth,
                CreatedBy = 1,
                CreatedDate = DateTime.Now,
                Gender = registerDtos.Gender,
                UpdatedBy =1,
                UpdatedDate = DateTime.Now
            };

            return this.userRepository.SaveUser(user);
        }
    }
}
