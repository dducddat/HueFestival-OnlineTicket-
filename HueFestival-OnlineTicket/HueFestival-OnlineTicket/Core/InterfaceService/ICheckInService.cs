using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface ICheckInService
    {
        Task<dynamic> CheckInAsync(string code, string employeeId);
    }
}
