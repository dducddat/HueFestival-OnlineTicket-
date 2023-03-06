using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IShowService
    {
        Task<int> AddAsync(ShowVM_Input input);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id, ShowVM_Input input);
        Task<IEnumerable<dynamic>> GetCalendarList();
        Task<List<ShowVM>> GetByDate(DateTime date);
    }
}
