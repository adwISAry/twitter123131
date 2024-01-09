using TwitterClone.Business.Dtos.TopicDtos;

namespace TwitterClone.Business.Services.Interfaces
{
    public interface ITopicService
    {
        public IQueryable<TopicDetailsDto> GetAll();
        public Task<TopicDetailDto> GetByIdAsync(int id);
        public Task CreateAsync(TopicCreateDto dto);
    }
}
