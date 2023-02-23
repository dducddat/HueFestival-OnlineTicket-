using AutoMapper;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Helpers
{
    public class LocationCategoryMapper : Profile
    {

        public LocationCategoryMapper() 
        {
            CreateMap<LocationCategory, LocationCategoryVM_Input>().ReverseMap();

            CreateMap<LocationCategory, LocationCategoryVM>().ReverseMap();
        }
    }
}
