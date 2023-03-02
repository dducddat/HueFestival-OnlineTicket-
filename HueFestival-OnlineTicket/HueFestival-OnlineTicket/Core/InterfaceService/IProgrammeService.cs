using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.InterfaceService
{
    public interface IProgrammeService
    {
        Task AddAsync(ProgrammeVM_Input input);
        Task<bool> DeleteAsync(int id);
    }
}
