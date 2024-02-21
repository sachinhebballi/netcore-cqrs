using AutoMapper;
using Domain = Api.Models.Domain;
using Request = Api.Models.Models;

namespace Api.Application.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Domain.Employee, Request.Employee>().ReverseMap();
            CreateMap<Domain.Address, Request.Address>().ReverseMap();
        }
    }
}
