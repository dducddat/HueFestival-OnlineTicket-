using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class ShowFavoriteRepository : GenericRepository<ShowFavorite>, IShowFavoriteRepository
    {
        public ShowFavoriteRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<ShowFavorite> GetShowFavoriteAsync(Guid id)
            => await context.ShowFavorites.SingleOrDefaultAsync(x => x.Id == id);
    }
}
