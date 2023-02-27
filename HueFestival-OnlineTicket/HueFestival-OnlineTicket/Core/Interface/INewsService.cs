using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Interface
{
    public interface INewsService 
    {
        Task<List<NewsVM>> GetAllAsync();
        Task<bool> AddAsync(NewsVM_Input input);
        Task<bool> DeleteAsync(int id);
        Task<NewsVM_Details> GetDetailsAsync(int id);
        Task<bool> UpdateAsync(NewsVM_Update input);
        Task<NewsVM_Update> UpdateAsync(int id);
    }
}
