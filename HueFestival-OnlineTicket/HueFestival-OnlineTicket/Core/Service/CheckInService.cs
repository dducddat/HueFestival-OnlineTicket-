using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class CheckInService : ICheckInService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CheckInService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<dynamic> CheckInAsync(string code, string employeeId)
        {
            var ticket = await unitOfWork.TicketRepo.GetByCode(code);

            if(ticket == null)
                return new { Message = "Vé không hợp lệ", Success = false};
            if (ticket.Status == true)
                return new { Message = "Vé đã check in trước đó", Success = false };

            ticket.Status = true;
            unitOfWork.TicketRepo.Update(ticket);

            await unitOfWork.CheckInRepo.AddAsync(new CheckIn
            {
                Id = Guid.NewGuid(),
                TicketId = ticket.Id,
                EmployeeId = Guid.Parse(employeeId),
                Status = true,
                DateCreated = DateTime.Now
            });
            await unitOfWork.CommitAsync();

            return new { Message = "Vé hợp lệ", Data = mapper.Map<TicketVM>(ticket), Success = true };
        }
    }
}
