using AutoMapper;
using Infotech.TestTask.Webapi.Models;

namespace Infotech.TestTask.Webapi.Dto
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}