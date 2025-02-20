using MovieSeries.CoreLayer.Entities;
using MovieSeries.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSeries.ServiceLayer.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _tagRepository.GetByIdAsync(id);
        }

        public async Task AddTagAsync(Tag tag)
        {
            // Có thể thêm các kiểm tra nghiệp vụ ở đây (ví dụ: kiểm tra trùng lặp)
            await _tagRepository.AddAsync(tag);
        }

        public async Task UpdateTagAsync(Tag tag)
        {
            await _tagRepository.UpdateAsync(tag);
        }

        public async Task DeleteTagAsync(int id)
        {
            await _tagRepository.DeleteAsync(id);
        }
    }
}
