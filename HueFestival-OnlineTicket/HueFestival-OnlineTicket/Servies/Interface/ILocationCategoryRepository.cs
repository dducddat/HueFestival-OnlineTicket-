using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Servies.Interface
{
    public interface ILocationCategoryRepository
    {
        Task AddAsync(LocationCategoryVM_Input locationCategoryVM_Input);

        Task<List<LocationCategoryVM>> GetAllAsync();

        Task<LocationCategoryVM> EditAsync(int id);

        Task<int> EditAsync(int id, LocationCategoryVM locationCategoryVM);

        Task<int> DeleteAsync(int id);

        Task<LocationCategoryVM_Details> GetByIdAsync(int id);
    }
}
