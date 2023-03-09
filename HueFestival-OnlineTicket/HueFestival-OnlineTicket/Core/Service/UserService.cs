using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<bool> AddAsync(UserVM_Input input)
        {
            try
            {
                var user = mapper.Map<User>(input);

                var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(input.Password, workFactor: 13);
                user.Password = passwordHash;

                await unitOfWork.UserRepo.AddAsync(user);
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> LoginAsync(UserVM_Login input)
        {
            var user = await unitOfWork.UserRepo.GetByEmailAsync(input.Email);

            if(user == null)
                return new { Success = false, Message = "User not found" };

            if (BCrypt.Net.BCrypt.EnhancedVerify(input.Password, user.Password))
                return new { Success = true, Message = "login successfully" };

            return new { Success = false, Message = "Wrong password" };
        }
    }
}
