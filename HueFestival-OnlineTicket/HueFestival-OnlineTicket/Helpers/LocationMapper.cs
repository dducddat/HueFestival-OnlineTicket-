using AutoMapper;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival_OnlineTicket.Helpers
{
    public class LocationMapper : Profile
    {
        public LocationMapper() 
        {
            CreateMap<Location, LocationVM>().ReverseMap();

            CreateMap<Location, LocationVM_Input>().ReverseMap();
        }
    }
}
