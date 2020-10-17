using Domain = Api.Models.Domain;
using Request = Api.Models.Models;
using AutoMapper;
using System.Collections.Generic;

namespace Api.Application.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Domain.Employee, Request.Employee>().ReverseMap();
            CreateMap<Domain.Address, Request.Address>().ReverseMap();
            CreateMap<IEnumerable<Domain.Employee>, IEnumerable<Request.Employee>>().ReverseMap();
        }
    }
}
