using AutoMapper;
using Mock.Core.Models;

namespace Mock.Bussiness.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Borrowing, BorrowingDTO>()
           .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FirstName+src.User.LastName)).ReverseMap();
             

            CreateMap<RegisterDTO, User>();

        }
    }
}
