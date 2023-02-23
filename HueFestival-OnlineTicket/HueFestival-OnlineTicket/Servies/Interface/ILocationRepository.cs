using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Servies.Interface
{
    public interface ILocationRepository
    {
        Task AddAsync(LocationVM_Input locationVM_Input);

        Task<LocationVM_Details> GetByIdAsync(int id);

        Task<LocationVM_Details> EditAsync(int id);

        Task<int> EditAsync(int id, LocationVM_Details locationVM_Details);

        Task<int> DeleteAsync(int id);
    }
}
