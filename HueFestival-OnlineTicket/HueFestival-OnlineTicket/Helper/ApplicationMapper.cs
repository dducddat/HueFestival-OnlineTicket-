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
            CreateMap<Location, LocationVM_Details>()
                .ForMember(des => des.LocationCategory, act => act.MapFrom(src => src.LocationCategory.Title));

            CreateMap<TicketLocation, TicketLocationVM>().ReverseMap();
            CreateMap<TicketLocation, TicketLocationVM_Input>().ReverseMap();

            CreateMap<News, NewsVM_Input>().ReverseMap();
            CreateMap<News, NewsVM>().ReverseMap();
            CreateMap<News, NewsVM_Details>().ReverseMap();

            CreateMap<HelpMenu, HelpMenuVM>().ReverseMap();
            CreateMap<HelpMenu, HelpMenuVM_Input>().ReverseMap();
            CreateMap<HelpMenu, HelpMenuVM_Details>().ReverseMap();

            CreateMap<Programme, ProgrammeVM>().ReverseMap();
            CreateMap<Programme, ProgrammeVM_Details>().ReverseMap();
            CreateMap<Programme, ProgrammeVM_Input>().ReverseMap();

            CreateMap<ProgrammeImage, ProgrammeImageVM>().ReverseMap();

            CreateMap<Show, ShowVM>()
                .ForMember(des => des.ProgramName, act => act.MapFrom(src => src.Programme.Name))
                .ForMember(des => des.LocationTitle, act => act.MapFrom(src => src.Location.Title))
                .ForMember(des => des.Time, act => act.MapFrom(src => src.StartDate.ToString("HH:mm:ss")))
                .ForMember(des => des.Type_Inoff, act => act.MapFrom(src => src.Programme.Type_Inoff));
            CreateMap<Show, ShowVM_Details>()
                .ForMember(des => des.ProgramName, act => act.MapFrom(src => src.Programme.Name))
                .ForMember(des => des.LocationTitle, act => act.MapFrom(src => src.Location.Title))
                .ForMember(des => des.Time, act => act.MapFrom(src => src.StartDate.ToString("HH:mm:ss")))
                .ForMember(des => des.Price, act => act.MapFrom(src => src.Programme.Price))
                .ForMember(des => des.ShowCategoryName, act => act.MapFrom(src => src.ShowCategory.Name))
                .ForMember(des => des.ShowCategoryContent, act => act.MapFrom(src => src.ShowCategory.Content));
            CreateMap<Show, ShowVM_Input>().ReverseMap();

            CreateMap<ShowCategory, ShowCategoryVM_Input>().ReverseMap();
            CreateMap<ShowCategory, ShowCategoryVM>().ReverseMap();

            CreateMap<User, UserVM_Input>().ReverseMap();
            CreateMap<User, UserVM>().ReverseMap();

            CreateMap<LocationFavorite, LocationFavoriteVM>()
                .ForMember(des => des.LocationTitle, act => act.MapFrom(src => src.Location.Title))
                .ForMember(des => des.LocationImage, act => act.MapFrom(src => src.Location.Image));

            CreateMap<ShowFavorite, ShowFavoriteVM>()
                .ForMember(des => des.ProgrammeName, act => act.MapFrom(src => src.Show.Programme.Name))
                .ForMember(des => des.ListProgrammeImage, act => act.MapFrom(src => src.Show.Programme.ListProgrammeImage));
        }
    }
}
