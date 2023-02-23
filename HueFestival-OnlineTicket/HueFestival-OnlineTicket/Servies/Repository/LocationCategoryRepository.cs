using AutoMapper;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Servies.Repository
{
    public class LocationCategoryRepository : ILocationCategoryRepository
    {
        private readonly HueFestivalContext _db;
        private readonly IMapper _mapper;

        public LocationCategoryRepository(HueFestivalContext db,
                                  IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddAsync(LocationCategoryVM_Input locationCategoryVM_Input)
        {
            _db.Add(_mapper.Map<LocationCategory>(locationCategoryVM_Input));
            await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var locationCategory = await GetLocationCategoryAsync(id);

            if (locationCategory == null)
                return 0;

            locationCategory.Remove = true;

            _db.Update(locationCategory);
            await _db.SaveChangesAsync();

            return 1;
        }

        public async Task<LocationCategoryVM> EditAsync(int id)
        {
            var result = await GetLocationCategoryAsync(id);

            return _mapper.Map<LocationCategoryVM>(result);
        }

        public async Task<int> EditAsync(int id, LocationCategoryVM locationCategoryVM)
        {
            var locationCategory = await GetLocationCategoryAsync(locationCategoryVM.Id);

            if (locationCategory == null)
                return 0;

            locationCategory.Title = locationCategoryVM.Title;
            locationCategory.Image = locationCategoryVM.Image;

            _db.Update(locationCategory);
            await _db.SaveChangesAsync();

            return 1;
        }

        public async Task<List<LocationCategoryVM>> GetAllAsync()
        {
            var result = await _db.LocationsCategories.Where(lc => lc.Remove == false)
                                                      .ToListAsync();

            return _mapper.Map<List<LocationCategoryVM>>(result);
        }

        public async Task<LocationCategoryVM_Details> GetByIdAsync(int id)
        {
            var locationCategory = await GetLocationCategoryAsync(id);

            if (locationCategory == null)
                return null;

            var location = await _db.Locations.Where(l => l.LocationCategoryId == id && 
                                                          l.Remove == false)
                                              .ToListAsync();

            return new LocationCategoryVM_Details {Id = locationCategory.Id, 
                                                   Title = locationCategory.Title, 
                                                   Image = locationCategory.Image,
                                                   ListLocationVM = _mapper.Map<List<LocationVM>>(location)};
        }

        private async Task<LocationCategory?> GetLocationCategoryAsync(int id)
        {
            return await _db.LocationsCategories.Where(lc => lc.Id == id &&
                                                                   lc.Remove == false)
                                                      .SingleOrDefaultAsync();
        }
    }
}
