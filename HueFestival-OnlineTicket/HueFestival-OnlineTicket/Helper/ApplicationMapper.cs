using AutoMapper;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<LocationCategory, LocationCategoryVM_Input>().ReverseMap();
            CreateMap<LocationCategory, LocationCategoryVM>().ReverseMap();
            CreateMap<LocationCategory, LocationCategoryVM_Details>().ReverseMap();

            CreateMap<Location, LocationVM>().ReverseMap();
            CreateMap<Location, LocationVM_Input>().ReverseMap();
            CreateMap<Location, LocationVM_Update>().ReverseMap();
            CreateMap<Location, LocationVM_Details>()
                .ForMember(des => des.LocationCategory, act => act.MapFrom(src => src.LocationCategory.Title));

            CreateMap<TicketLocation, TicketLocationVM>().ReverseMap();
            CreateMap<TicketLocation, TicketLocationVM_Input>().ReverseMap();

            CreateMap<News, NewsVM_Input>().ReverseMap();
            CreateMap<News, NewsVM>().ReverseMap();
            CreateMap<News, NewsVM_Details>().ReverseMap();
            CreateMap<News, NewsVM_Update>().ReverseMap();
        }
    }
}
