using HueFestival_OnlineTicket.Servies.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HueFestival_OnlineTicket.Data
{
    public interface IUnitOfWork
    {
        ILocationCaegoryRepository LocationCategoryRepo{ get; }
        ILocationRepository LocationRepo { get; }
        ITicketLocationRepository TicketLocationRepo { get; }
        INewsRepository NewsRepo { get; }

        void Commit();
        void RollBack();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
