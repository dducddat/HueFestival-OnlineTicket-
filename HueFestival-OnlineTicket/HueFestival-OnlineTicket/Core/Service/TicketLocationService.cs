using AutoMapper;
using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class TicketLocationService : ITicketLocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TicketLocationService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddASync(TicketLocationVM_Input ticketLocationVM_Input)
        {
            await unitOfWork.TicketLocationRepo.AddAsync(mapper.Map<TicketLocation>(ticketLocationVM_Input));
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticketLocation = await unitOfWork.TicketLocationRepo.GetByIdAsync(id);

            if(ticketLocation is null)
                return false;

            unitOfWork.TicketLocationRepo.Delete(ticketLocation);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<TicketLocationVM>> GetAllAsync()
            => mapper.Map<List<TicketLocationVM>>(await unitOfWork.TicketLocationRepo.GetAllAsync());

        public async Task<TicketLocationVM> GetByIdAsync(int id)
            => mapper.Map<TicketLocationVM>(await unitOfWork.TicketLocationRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(TicketLocationVM ticketLocationVM)
        {
            try
            {
                unitOfWork.TicketLocationRepo.Update(mapper.Map<TicketLocation>(ticketLocationVM));
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
