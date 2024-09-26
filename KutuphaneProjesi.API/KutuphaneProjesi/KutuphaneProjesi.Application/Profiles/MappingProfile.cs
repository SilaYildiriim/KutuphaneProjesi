using AutoMapper;
using KutuphaneProjesi.Application.Models.Book;
using KutuphaneProjesi.Application.Models.User;
using KutuphaneProjesi.Domain.Entities;

namespace KutuphaneProjesi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>().ReverseMap();
            CreateMap<SendBackBookDto, Book>().ReverseMap();

            CreateMap<LoginDto, User>().ReverseMap();
            CreateMap<UserWithRoleDto, UserRole>().ReverseMap();

        }
    }
}
