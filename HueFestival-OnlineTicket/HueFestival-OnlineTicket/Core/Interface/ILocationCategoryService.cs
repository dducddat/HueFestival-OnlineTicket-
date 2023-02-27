using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Interface
{
    public interface ILocationCategoryService
    {
        Task<List<LocationCategoryVM>> GetAllAsync();
        Task<LocationCategoryVM_Details> GetByIdAsync(int id);
        Task AddAsync(LocationCategoryVM_Input locationCategoryVM_Input);
        Task<LocationCategoryVM> UpdateAsync(int id);
        Task<bool> UpdateAsync(LocationCategoryVM locationCategoryVM);
        Task<bool> DeleteAsync(int id);
    }
}
