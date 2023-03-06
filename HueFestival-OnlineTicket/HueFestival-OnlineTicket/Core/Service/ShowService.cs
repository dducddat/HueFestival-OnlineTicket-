using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class ShowService : IShowService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ShowService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<int> AddAsync(ShowVM_Input input)
        {
            try
            {
                var programme = await unitOfWork.ProgrammeRepo.CheckProgrammeExistAsync(input.ProgramId);
                var Location = await unitOfWork.LocationRepo.CheckExistAsync(input.LocationId);
                var showCategory = await unitOfWork.ShowCategoryRepo.CheckExistAsync(input.ShowCategoryId);

                if(!programme && !Location && !showCategory) 
                {
                    return 1;
                }

                await unitOfWork.ShowRepo.AddAsync(mapper.Map<Show>(input));
                await unitOfWork.CommitAsync();

                return 3;
            }
            catch
            {
                return 2;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<dynamic>> GetCalendarList()
            => await unitOfWork.ShowRepo.GetCalendarList();

        public async Task<List<ShowVM>> GetByDate(DateTime date)
            => mapper.Map<List<ShowVM>>(await unitOfWork.ShowRepo.GetByDate(date));

        public Task<int> UpdateAsync(int id, ShowVM_Input input)
        {
            throw new NotImplementedException();
        }
    }
}
