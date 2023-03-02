﻿using HueFestival_OnlineTicket.Model;
using Microsoft.EntityFrameworkCore;

namespace HueFestival_OnlineTicket.Data
{
    public class HueFestivalContext : DbContext
    {
        public HueFestivalContext(DbContextOptions<HueFestivalContext> options)
            : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCategory> LocationsCategories { get; set; }
        public DbSet<TicketLocation> TicketLocations { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<HelpMenu> HelpMenus { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ProgrammeImage> ProgramImages { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowCategory> ShowCategories { get; set; }
    }
}
