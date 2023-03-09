using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class LocationFavoriteRepository : GenericRepository<LocationFavorite>, ILocationFavoriteRepository
    {
        public LocationFavoriteRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<LocationFavorite> GetFavoriteAsync(Guid id)
            => await context.LocationFavorites.SingleOrDefaultAsync(x => x.Id == id);
    }
}
