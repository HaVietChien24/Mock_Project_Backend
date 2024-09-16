using AutoMapper;
using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Borrowing, BorrowingDTO>()
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FirstName+src.User.LastName)).ReverseMap();
            
           
        }
    }
}
