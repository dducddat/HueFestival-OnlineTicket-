using AutoMapper;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Helpers
{
    public class TicketLocationMapper : Profile
    {
        public TicketLocationMapper()
        {
            CreateMap<TicketLocation, TicketLocationVM>().ReverseMap();
        }
    }
}
