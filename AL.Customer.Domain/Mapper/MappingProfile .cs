using AL.Customer.Data.DbModels;
using AL.Customer.Effigy.DTOModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.Customer.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dto => dto.UserName, opt => opt.MapFrom(src => src.UserName));
        }

    }
}
