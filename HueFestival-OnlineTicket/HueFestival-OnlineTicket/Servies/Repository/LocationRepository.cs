using AutoMapper;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Migrations;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.Servies.Interface;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Servies.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly HueFestivalContext _db;
        private readonly IMapper _mapper;

        public LocationRepository(HueFestivalContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddAsync(LocationVM_Input locationVM_Input)
        {
            _db.Add(_mapper.Map<Location>(locationVM_Input));
            await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var location = await GetLocationAsync(id);

            if(location is null)
                return 0;

            location.Remove = true;

            _db.Update(location);
            await _db.SaveChangesAsync();

            return 1;
        }

        public async Task<LocationVM_Details> EditAsync(int id)
        {
            var location = await GetLocationVM_DetailsAsync(id);

            return location;
        }

        public async Task<int> EditAsync(int id, LocationVM_Details locationVM_Details)
        {
            var location = await GetLocationAsync(locationVM_Details.Id);

            if(location is null) 
                return 0;

            location.Latitude = locationVM_Details.Latitude;
            location.LocationCategoryId = locationVM_Details.LocationCategoryId;
            location.Title = locationVM_Details.Title;
            location.Summary = locationVM_Details.Summary;
            location.Content = locationVM_Details.Content;
            location.Longtitude = locationVM_Details.Longtitude;
            location.Image = locationVM_Details.Image;

            _db.Update(location);
            await _db.SaveChangesAsync();

            return 1;
        }

        public async Task<LocationVM_Details> GetByIdAsync(int id)
        {
            var location = await GetLocationVM_DetailsAsync(id);

            return location;
        }

        private async Task<LocationVM_Details?> GetLocationVM_DetailsAsync(int id)
        {
            var location = await _db.Locations.Include(l => l.LocationCategory)
                                      .Where(l => l.Id == id &&
                                                  l.Remove == false)
                                      .SingleOrDefaultAsync();

            if (location is null)
                return null;

            return new LocationVM_Details {Id = location.Id, 
                                           LocationCategoryId = location.LocationCategoryId,
                                           Title = location.Title,
                                           Summary = location.Summary,
                                           Content = location.Content,
                                           Image = location.Image,
                                           Latitude = location.Latitude,
                                           Longtitude = location.Longtitude,
                                           LocationCategory = location.LocationCategory.Title};
        }

        private async Task<Location?> GetLocationAsync(int id) 
        {
            return await _db.Locations.Where(l => l.Id == id &&
                                                  l.Remove == false)
                                      .FirstOrDefaultAsync();
        } 
    }
}
