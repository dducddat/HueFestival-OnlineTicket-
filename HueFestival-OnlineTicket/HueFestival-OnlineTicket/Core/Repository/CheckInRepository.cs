﻿using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Service.Repository;

namespace HueFestival_OnlineTicket.Core.Repository
{
    public class CheckInRepository : GenericRepository<CheckIn>, ICheckInRepository
    {
        public CheckInRepository(HueFestivalContext _context) : base(_context)
        {
        }
    }
}
