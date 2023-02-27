using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Interface
{
    public interface ITicketLocationService
    {
        Task AddASync(TicketLocationVM_Input ticketLocationVM_Input);
        Task<bool> DeleteAsync(int id);
        Task<List<TicketLocationVM>> GetAllAsync();
        Task<TicketLocationVM> GetByIdAsync(int id);
        Task<bool> UpdateAsync(TicketLocationVM ticketLocationVM);
    }
}
