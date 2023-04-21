using AutoMapper;
using HotWheels.App.Application;
using HotWheelsApp.Domain;

namespace HotWheelsAPI.AutoMapper
{
    public class HotWheelsMapper : Profile
    {
        public HotWheelsMapper()
        {
            CreateMap<HotWheel, HotWheelDTO>().ReverseMap();
        }

    }
}
