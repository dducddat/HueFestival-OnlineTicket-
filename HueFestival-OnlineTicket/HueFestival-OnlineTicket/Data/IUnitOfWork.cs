﻿using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Core.InterfaceRepository;
using HueFestival_OnlineTicket.Servies.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HueFestival_OnlineTicket.Data
{
    public interface IUnitOfWork
    {
        ILocationCaegoryRepository LocationCategoryRepo{ get; }
        ILocationRepository LocationRepo { get; }
        ITicketLocationRepository TicketLocationRepo { get; }
        INewsRepository NewsRepo { get; }
        IHelpMenuRepository HelpMenuRepo { get; }
        IProgrammeRepository ProgrammeRepo { get; }
        IProgrammeImageRepository ProgrammeImageRepo { get; }

        void Commit();
        void RollBack();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
