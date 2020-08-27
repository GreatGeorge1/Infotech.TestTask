using AutoMapper;
using Infotech.TestTask.Webapi.Models;

namespace Infotech.TestTask.Webapi.Dto
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>();
        }
    }
}