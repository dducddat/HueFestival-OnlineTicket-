using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IUserService
    {
        Task<bool> AddAsync(UserVM_Input input);
        Task<bool> DeleteAsync(int id);
        Task<dynamic> LoginAsync(UserVM_Login input);
    }
}
