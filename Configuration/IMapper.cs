using AutoMapper;
using Backend.Data;
using Backend.Dtos.Body;
using Backend.Dtos.Company;
using Backend.Dtos.Model;
using Backend.Dtos.Trim;
using Backend.Dtos.User;

namespace Backend.Configuration
{
    public class IMapper : Profile
    {
        public IMapper()
        {
            CreateMap<Body, GetBodyDto>().ReverseMap();
            CreateMap<Body, CreateBodyDto>().ReverseMap();
            CreateMap<Body, UpdateBodyDto>().ReverseMap();

            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyDetailsDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, SearchCompanyDto>().ReverseMap();
            CreateMap<Company, GetCompanyNameDto>().ReverseMap();
            CreateMap<Company, AllCompaniesDto>().ReverseMap();

            CreateMap<Model, GetModelDto>().ReverseMap();
            CreateMap<Model, CreateModelDto>().ReverseMap();
            CreateMap<Model, ModelDetailsDto>().ReverseMap();
            CreateMap<Model, UpdateModelDto>().ReverseMap();
            CreateMap<Model, SearchModelDto>().ReverseMap();

            CreateMap<Trim, GetTrimDto>().ReverseMap();
            CreateMap<Trim, CreateTrimDto>().ReverseMap();
            CreateMap<Trim, GetDetailsTrimDto>().ReverseMap();
            CreateMap<Trim, UpdateTrimDto>().ReverseMap();

            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, CreateBookingDto>().ReverseMap();


            CreateMap<ApiUserDto, ApiUser>().ReverseMap();
            CreateMap<GetUserDto, ApiUser>().ReverseMap();

        }
    }
}
