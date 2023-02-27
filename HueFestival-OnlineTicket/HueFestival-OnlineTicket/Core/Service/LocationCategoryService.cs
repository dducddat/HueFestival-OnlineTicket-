using AutoMapper;
using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class LocationCategoryService : ILocationCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LocationCategoryService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddAsync(LocationCategoryVM_Input locationCategoryVM_Input)
        {
            await unitOfWork.LocationCategoryRepo.AddAsync(mapper.Map<LocationCategory>(locationCategoryVM_Input));
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var locationCatrgory = await unitOfWork.LocationCategoryRepo.GetByIdAsync(id);

            if (locationCatrgory is null)
                return false;

            unitOfWork.LocationCategoryRepo.Delete(locationCatrgory);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<LocationCategoryVM>> GetAllAsync()
            => mapper.Map<List<LocationCategoryVM>>(await unitOfWork.LocationCategoryRepo.GetAllAsync());

        public async Task<LocationCategoryVM_Details> GetByIdAsync(int id)
            => mapper.Map<LocationCategoryVM_Details>(await unitOfWork.LocationCategoryRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(LocationCategoryVM locationCategoryVM)
        {
            try
            {
                unitOfWork.LocationCategoryRepo.Update(mapper.Map<LocationCategory>(locationCategoryVM));
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<LocationCategoryVM> UpdateAsync(int id)
            => mapper.Map<LocationCategoryVM>(await unitOfWork.LocationCategoryRepo.GetByIdAsync(id));
    }
}
