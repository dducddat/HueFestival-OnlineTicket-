using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Interface
{
    public interface ILocationService
    {
        Task<bool> AddAsync(LocationVM_Input locationVM_Input);
        Task<bool> DeleteAsync(int id);
        Task<LocationVM_Details> GetByIdAsync(int id);
        Task<LocationVM_Update> UpdateAsync(int id);
        Task<bool> UpdateAsync(LocationVM_Update locationVM_Update);
    }
}
