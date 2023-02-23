using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Servies.Interface
{
    public interface ITickerLocationRepository
    {
        Task AddAsync(TicketLocationVM_Input ticketLocationVM_Input);

        Task<int> DeleteAsync(int id);

        Task<TicketLocationVM> EditAsync(int id);

        Task<int> EditAsync(int id, TicketLocationVM ticketLocationVM);

        Task<List<TicketLocationVM>> GetAllAsync();
    }
}
