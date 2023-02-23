using AutoMapper;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Servies.Repository
{
    public class TicketLoactionRepository : ITickerLocationRepository
    {
        private readonly HueFestivalContext _db;
        private readonly IMapper _mapper;

        public TicketLoactionRepository(HueFestivalContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddAsync(TicketLocationVM_Input ticketLocationVM_Input)
        {
            _db.Add(new TicketLocation{ Name = ticketLocationVM_Input.Name,
                                        Address = ticketLocationVM_Input.Address,
                                        PhoneNumber = ticketLocationVM_Input.PhoneNumber,
                                        Image = ticketLocationVM_Input.Image,
                                        Remove = false });
            await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var ticketLocation = await GetTicketLocationAsync(id);

            if (ticketLocation == null)
                return 0;

            ticketLocation.Remove = true;

            _db.Update(ticketLocation);
            await _db.SaveChangesAsync();

            return 1;
        }

        public async Task<TicketLocationVM> EditAsync(int id)
        {
            var ticketLocation = await GetTicketLocationAsync(id);

            if (ticketLocation == null)
                return null;

            return _mapper.Map<TicketLocationVM>(ticketLocation);
        }

        public async Task<int> EditAsync(int id, TicketLocationVM ticketLocationVM)
        {
            var ticketLocation = await GetTicketLocationAsync(id);

            if (ticketLocation == null)
                return 0;

            ticketLocation.PhoneNumber = ticketLocationVM.PhoneNumber;
            ticketLocation.Address = ticketLocationVM.Address;
            ticketLocation.Image = ticketLocationVM.Image;
            ticketLocation.Name = ticketLocationVM.Name;

            _db.Update(ticketLocation);
            await _db.SaveChangesAsync();

            return 1;
        }

        public async Task<List<TicketLocationVM>> GetAllAsync()
        {
            var ticketLocations = await _db.TicketLocations.Where(tl => tl.Remove == false)
                                                           .ToListAsync(); 
            
            return _mapper.Map<List<TicketLocationVM>>(ticketLocations);
        }

        private async Task<TicketLocation?> GetTicketLocationAsync(int id)
        {
            return await _db.TicketLocations.Where(tl => tl.Id == id &&
                                                         tl.Remove == false)
                                            .SingleOrDefaultAsync();
        }
    }
}
