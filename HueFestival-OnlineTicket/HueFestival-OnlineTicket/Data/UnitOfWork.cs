
using AutoMapper;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.Servies.Repository;

namespace HueFestival_OnlineTicket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HueFestivalContext context;
        public ILocationCaegoryRepository LocationCategoryRepo { get; private set; }
        public ILocationRepository LocationRepo { get; private set; }
        public ITicketLocationRepository TicketLocationRepo { get; private set; }
        public INewsRepository NewsRepo { get; private set; }

        public UnitOfWork(HueFestivalContext _context)
        {
            context = _context;
            LocationCategoryRepo = new LocationCategoryRepository(context);
            LocationRepo = new LocationRepository(context);
            TicketLocationRepo = new TicketLoactionRepository(context);
            NewsRepo = new NewsRepository(context);
        }

        public void Commit() => context.SaveChanges();

        public async Task CommitAsync() => await context.SaveChangesAsync();

        public void RollBack() => context.Dispose();

        public async Task RollBackAsync() => await context.DisposeAsync();
    }
}
