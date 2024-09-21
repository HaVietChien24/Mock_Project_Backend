using AutoMapper;
using Mock.Core.Models;

namespace Mock.Bussiness.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Borrowing, BorrowingDTO>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.FirstName + src.User.LastName))
                .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src => src.BorrowingDetails.Sum(bd => bd.Quantity)))
                .ReverseMap();


            CreateMap<BorrowingDetails, BorrowingDetailDTO>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Title))
                .ReverseMap();

            

            CreateMap<BorrowingDetails, BorrowingDetailDTO>()
           .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Title))
           .ForMember(dest =>dest.IsPickUpLate,opt=>opt.MapFrom(src=>src.Borrowing.IsPickUpLate))
           .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Book.ImageUrl))
           .ForMember(dest=>dest.IsBookPickedUp,opt=>opt.MapFrom(src=>src.Borrowing.IsBookPickedUp))
           .ReverseMap();
         
          


            CreateMap<RegisterDTO, User>();

            CreateMap<UpdateProfileDTO, User>();

            CreateMap<Genre, GenreDTO>();
            CreateMap<Book, BookDTO>().ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.BookGenres.Select(bg => bg.Genre.Name).ToList())).ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<WishList, WishlistDTO>()
                .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src => src.WishListDetails.Sum(wld => wld.Quantity))).ReverseMap();
            CreateMap<WishListDetails, WishListDetailsDTO>().ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Book.ImageUrl)).ReverseMap();
            CreateMap<RequestDTO, Borrowing>();
            CreateMap<BorrowingDetails, RequestDetailsDTO>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Book.ImageUrl));
            CreateMap<Borrowing, RequestDTO>().ForMember(dest => dest.RequestDetails, opt => opt.MapFrom(src => src.BorrowingDetails))
                .ForMember(dest => dest.TotalQuantity, opt => opt.MapFrom(src => src.BorrowingDetails.Sum(bd => bd.Quantity)));
            CreateMap<WishListDetails, BorrowingDetails>();
        }
    }
}
