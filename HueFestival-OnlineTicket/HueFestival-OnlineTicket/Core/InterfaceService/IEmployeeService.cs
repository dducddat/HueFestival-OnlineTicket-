﻿using HueFestival_OnlineTicket.Model;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<Employee> GetByIdAsync(Guid id);
        Task UpdateAsync(Employee employee);
        Task<Employee> GetByPhoneAsync(string phone);
        Task<Employee> LoginAsync(string username, string password);
        Task<bool> ActivateAsync(string phone);
    }
}
