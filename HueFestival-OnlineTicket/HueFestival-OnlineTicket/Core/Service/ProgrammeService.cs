using AutoMapper;
using HueFestival_OnlineTicket.Core.InterfaceService;
using HueFestival_OnlineTicket.Data;
using HueFestival_OnlineTicket.Model;
using HueFestival_OnlineTicket.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace HueFestival_OnlineTicket.Core.Service
{
    public class ProgrammeService : IProgrammeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProgrammeService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddAsync(ProgrammeVM_Input input)
        {
            Programme programme = new Programme { 
                Name = input.Name,
                Content = input.Content,
                Type_Inoff = input.Type_Inoff,
                Type_Program = input.Type_Program,
                Price = input.Price,
            };

            await unitOfWork.ProgrammeRepo.AddAsync(programme);
            await unitOfWork.CommitAsync();

            var listImage = mapper.Map<List<ProgrammeImage>>(input.ListProgrammeImage);

            foreach (var image in listImage)
            {
                image.ProgrammeId = programme.Id;
                await unitOfWork.ProgrammeImageRepo.AddAsync(image);
            }

            await unitOfWork.CommitAsync();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
