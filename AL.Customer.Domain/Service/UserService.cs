using AL.Customer.Data.Interface;
using AL.Customer.Effigy.DTOModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Service
{
    public class UserService
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
            return mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}
