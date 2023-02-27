using AutoMapper;
using HueFestival_OnlineTicket.Core.Interface;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewsService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<bool> AddAsync(NewsVM_Input input)
        {
            try
            {
                await unitOfWork.NewsRepo.AddAsync(new News
                {
                    Title = input.Title,
                    Content = input.Content,
                    Image = input.Content,
                    CreatedDate = DateTime.Now
                });
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var news = await unitOfWork.NewsRepo.GetByIdAsync(id);

            if(news == null)
                return false;

            unitOfWork.NewsRepo.Delete(news); 
            await unitOfWork.CommitAsync();
            
            return true;
        }

        public async Task<List<NewsVM>> GetAllAsync()
            => mapper.Map<List<NewsVM>>(await unitOfWork.NewsRepo.GetAllAsync());

        public async Task<NewsVM_Details> GetDetailsAsync(int id)
            => mapper.Map<NewsVM_Details>(await unitOfWork.NewsRepo.GetByIdAsync(id));

        public async Task<bool> UpdateAsync(NewsVM_Update input)
        {
            try
            {
                unitOfWork.NewsRepo.Update(mapper.Map<News>(input));
                await unitOfWork.CommitAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<NewsVM_Update> UpdateAsync(int id)
            => mapper.Map<NewsVM_Update>(await unitOfWork.NewsRepo.GetByIdAsync(id));
    }
}
