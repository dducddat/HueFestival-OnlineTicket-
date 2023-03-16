using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public override async Task<List<Ticket>> GetAllAsync()
            => await context.Tickets.Include(t => t.TicketType).ThenInclude(tt => tt.Show).ThenInclude(s => s.Programme).ToListAsync();

        public async Task<Ticket> GetByCode(string code)
            => await context.Tickets.Include(t => t.TicketType).ThenInclude(tt => tt.Show).ThenInclude(s => s.Programme).SingleOrDefaultAsync(t => t.Code.Equals(code));

        public async Task<List<Ticket>> GetByUserIdAsync(int userId)
            => await context.Tickets.Include(t => t.TicketType).ThenInclude(tt => tt.Show).ThenInclude(s => s.Programme)
                                    .Where(t => t.UserId == userId).ToListAsync();
    }
}
