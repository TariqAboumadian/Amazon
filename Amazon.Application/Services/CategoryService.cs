using Amazon.Application.Contracts;
using Amazon.Domain;
using Amazon.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryReposatory;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryReposatory,IMapper mapper)
        {
            _CategoryReposatory = categoryReposatory;
            _mapper = mapper;
        }

        public async Task<CreateOrUpdateCategoryDTO> Create(CreateOrUpdateCategoryDTO category)
        {
            Category category1 = _mapper.Map<Category>(category);
            var res =await _CategoryReposatory.CreateAsync(category1);
            await _CategoryReposatory.SaveChangesAsync();
            return _mapper.Map<CreateOrUpdateCategoryDTO>(res);
        }

        public async Task<List<GetAllCAtegoriesDTO>> GetAllCategoryPagination(int item, int pagenumber)
        {
            var categories =await _CategoryReposatory.GetAllAsync();
            var paginatedCategory = categories.Skip(item * (pagenumber - 1)).Take(item).
                Select(p => _mapper.Map<GetAllCAtegoriesDTO>(p)).ToList();
            return paginatedCategory;
        }
    }
}
