using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HueFestivalContext _context) : base(_context)
        {
        }

        public async Task<User> GetByEmailAsync(string email)
            => await context.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
}
