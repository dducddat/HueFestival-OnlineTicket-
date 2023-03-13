using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Core.UnitOfWork;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;

        public UserService(IUnitOfWork _unitOfWork, IMapper _mapper, IMemoryCache _cache, IConfiguration _configuration)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
            cache = _cache;
            configuration = _configuration;
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

        public async Task<int> ChangePassword(int id, UserVM_ChangePassword input)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(id);

            if (user == null)
                return 1;

            if (!BCrypt.Net.BCrypt.EnhancedVerify(input.OldPassword, user.Password))
                return 2;

            var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(input.NewPassword, workFactor: 13);
            user.Password = passwordHash;

            unitOfWork.UserRepo.Update(user);
            await unitOfWork.CommitAsync();

            return 3;
        }

        public bool CheckOTP(int otp)
        {
            if(!cache.TryGetValue(otp, out var result)) 
            {
                return false;
            }

            int cacheOTP = cache.Get<int>(otp);

            if (cacheOTP != otp)
                return false;

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await unitOfWork.UserRepo.GetByIdAsync(id);

                if (user != null)
                {
                    unitOfWork.UserRepo.Delete(user);
                    await unitOfWork.CommitAsync();

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<UserVM>> GetAllAsync()
            => mapper.Map<List<UserVM>>(await unitOfWork.UserRepo.GetAllAsync());

        public async Task<UserVM_ShowAndLocationFavorite> GetAllShowAndLocationFavoriveAsync(int userId)
        {
            var locationFavorite = await unitOfWork.LocationFavoriteRepo.GetAllLocationFavoriteOfUserAsync(userId);
            var showFavorite = await unitOfWork.ShowFavoriteRepo.GetAllShowFavoritesOfUserAsync(userId);

            return new UserVM_ShowAndLocationFavorite
            {
                ListLocationFavorite = mapper.Map<List<LocationFavoriteVM>>(locationFavorite),
                ListShowFavorite = mapper.Map<List<ShowFavoriteVM>>(showFavorite)
            };
        }

        public int GetOTP(string phoneNumber)
        {
            Random rd = new Random();

            int otp = rd.Next(10000, 99999);

            var cacheExprityOption = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };

            cache.Set<int>(otp, otp, cacheExprityOption);

            return otp;
        }

        public async Task<string> LoginAsync(UserVM_Login input)
        {
            var user = await unitOfWork.UserRepo.GetByPhoneAsync(input.PhoneNumber);

            if(user == null)
                throw new Exception("Incorrect telephone number");

            if (!BCrypt.Net.BCrypt.EnhancedVerify(input.Password, user.Password))
                throw new Exception("Incorrect password");

            var jwt = GenerateToken(user);

            return jwt;
        }

        public async Task<bool> UpdateInfoAsync(UserVM_UpdateInfo input)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(input.Id);

            if(user != null)
            {
                user.Name = input.Name;
                user.Email = input.Email;
                user.PhoneNumber = input.PhoneNumber;

                unitOfWork.UserRepo.Update(user);
                await unitOfWork.CommitAsync();

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateRoleAsync(UserVM_UpdateRole input)
        {
            var user = await unitOfWork.UserRepo.GetByIdAsync(input.UserId);

            if(user != null)
            {
                user.Role = input.Role;

                unitOfWork.UserRepo.Update(user);
                await unitOfWork.CommitAsync();

                return true;
            }

            return false;
        }

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey").Value));

            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                Expires = DateTime.Now.AddHours(24),
                SigningCredentials = signinCredentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);

            return accessToken;
        }
    }
}
