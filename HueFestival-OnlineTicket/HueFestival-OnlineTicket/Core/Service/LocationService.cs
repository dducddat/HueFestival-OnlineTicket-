using AutoMapper;
using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<bool> AddAsync(LocationVM_Input locationVM_Input)
        {
            try
            {
                await unitOfWork.LocationRepo.AddAsync(mapper.Map<Location>(locationVM_Input));
                await unitOfWork.CommitAsync();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var location = await unitOfWork.LocationRepo.GetByIdAsync(id);

            if (location is null)
                return false;

            unitOfWork.LocationRepo.Delete(location);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<LocationVM_Details> GetByIdAsync(int id)
            => mapper.Map<LocationVM_Details>(await unitOfWork.LocationRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(LocationVM_Update locationVM_Update)
        {
            try
            {
                unitOfWork.LocationRepo.Update(mapper.Map<Location>(locationVM_Update));
                await unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<LocationVM_Update> UpdateAsync(int id)
            => mapper.Map<LocationVM_Update>(await unitOfWork.LocationRepo.GetByIdAsync(id));
    }
}
